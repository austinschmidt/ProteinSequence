
Public Structure genotype
    Dim Fitness As Integer
    Dim X() As Integer ' 1 to 64
    Dim Y() As Integer ' 1 to 64
End Structure

Public Class ProteinSequence
    Private Sub ProteinSequence_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public ValidFolding As Integer
    Public MutateCollision As Integer

    Public population(199) As genotype    '1st population
    Public newPopulation(199) As genotype '2nd population

    Public bestCollection(9) As genotype
    Public bestCollectionIncrement As Integer

    Public CurrentPositionOfInput As Integer = 0
    Public EndPositionOfInput As Integer = 0
    Public CurrentPositionOfBestCollection As Integer = 0
    Public CurrentPosOfNewPop As Integer

    Private Sub Start_Click(sender As Object, e As EventArgs) Handles Start.Click
        'Collection of important variables taken from GUI
        Dim input As New List(Of String)()
        input = ReadInput()
        Dim fitnessArray = CreateFitnessArray(input)
        Dim aminoArray = CreateAminoArray(input)

        Dim maxIterations As Long = txtMaximumIteration.Text
        Dim eliteRate As Double = txtEliteRate.Text
        Dim crossOverRate As Double = txtCrossOverRate.Text
        Dim mutationRate As Double = txtMutationRate.Text
        Dim populationSize As Long = txtPopulationSize.Text
        Dim drawingAmount As Long = txtDrawingAmount.Text

        ReDim population(populationSize - 1)
        ReDim newPopulation(populationSize - 1)
        ReDim bestCollection(drawingAmount - 1)

        'Initialization begun upon Start press.
        Dim i As Long
        Dim j As Long
        Dim l As Long
        'Loops through all input sequences.
        j = CurrentPositionOfInput
        EndPositionOfInput = aminoArray.Length
        bestCollectionIncrement = 0

        'Refresh GUI for the user.
        txtProteinLength.Text = aminoArray(j).Length
        txtProteinLength.Refresh()
        txtTargetValue.Text = fitnessArray(j)
        txtTargetValue.Refresh()
        lblSequence1.Text = "Sequence: " + Str(CurrentPositionOfInput + 1) + "/" + Str(EndPositionOfInput)
        lblSequence1.Refresh()
        'Middle of sequence for crossover.
        Dim middleOfSequence = Math.Floor(txtProteinLength.Text / 2)

        'Initialize random population.
        Initialize()

        'GA Approach
        For l = 0 To maxIterations - 1

            'Compute Fitness
            For i = 0 To txtPopulationSize.Text - 1
                Dim setFitness = ComputeInitialFitness(i, aminoArray(j))
                population(i).Fitness = setFitness
            Next i
            'sort
            SortPopByFitness()

            'Store best fitness for drawing
            AddBestCollection(l, drawingAmount, maxIterations)

            If (l = txtMaximumIteration.Text - 1) Then
                'If we hit max iterations, jump before edits are made.
                GoTo MyJump
            End If
            CurrentPosOfNewPop = 0

            'Save elites: Pop2 <- Pop1
            SaveElites(eliteRate, populationSize)
            'For m = 0 To populationSize - 1
            '   newPopulation(m) = population(m)
            'Next m
            CrossOverHandler(populationSize, aminoArray(j), crossOverRate)

            'Mutation
            MutationHandler(populationSize, aminoArray(j), mutationRate)

            'Pop1 <- Pop2
            For m = 0 To populationSize - 1
                population(m) = newPopulation(m)
            Next m
        Next l
MyJump:

        DrawTheBestFolding(0, aminoArray(j))
        Dim finalcheck = 0

    End Sub

    '********************************************************************
    'Find below a collection of methods for genetic algoritm techniques

    Private Sub Initialize()
        For i = 0 To txtPopulationSize.Text - 1
            ValidFolding = 0
            RandomOrientation(i)
            While (ValidFolding = 0)
                RandomOrientation(i)
            End While
        Next i
    End Sub

    'Initial random orientation for a population collection
    Private Function RandomOrientation(m As Long)
        Dim PreviousDirection, PresentDirection As Long
        Dim i, temp1, temp2, temp3, X, Y, j, Flag, Step2 As Long
        Dim a(0 To 3) As Long
        Dim Ax(0 To 3) As Long
        Dim Ay(0 To 3) As Long

        '                             2            3
        '  Select Direction as:     1 X 0        2 X 1
        '                             3            4
        '
        Dim b(0 To txtProteinLength.Text - 1) As Integer
        Dim c(0 To txtProteinLength.Text - 1) As Integer
        Dim init As genotype
        init.X = b
        init.Y = c
        init.Fitness = 100
        population(m) = init


        ValidFolding = 1
        population(m).X(0) = 0
        population(m).Y(0) = 0
        population(m).X(1) = 0
        population(m).Y(1) = 1
        PreviousDirection = 1

        For i = 2 To txtProteinLength.Text - 1
            Select Case PreviousDirection
                Case 1
                    a(1) = 1
                    Ax(1) = 1
                    Ay(1) = 0
                    a(2) = 3
                    Ax(2) = 0
                    Ay(2) = 1
                    a(3) = 4
                    Ax(3) = 0
                    Ay(3) = -1
                Case 2
                    a(1) = 2
                    Ax(1) = -1
                    Ay(1) = 0
                    a(2) = 3
                    Ax(2) = 0
                    Ay(2) = 1
                    a(3) = 4
                    Ax(3) = 0
                    Ay(3) = -1
                Case 3
                    a(1) = 1
                    Ax(1) = 1
                    Ay(1) = 0
                    a(2) = 2
                    Ax(2) = -1
                    Ay(2) = 0
                    a(3) = 3
                    Ax(3) = 0
                    Ay(3) = 1
                Case 4
                    a(1) = 1
                    Ax(1) = 1
                    Ay(1) = 0
                    a(2) = 2
                    Ax(2) = -1
                    Ay(2) = 0
                    a(3) = 4
                    Ax(3) = 0
                    Ay(3) = -1
            End Select

            temp1 = Int(3 * Rnd() + 1)
            PresentDirection = temp1
            temp2 = 0
            temp3 = 0
            X = population(m).X(i - 1) + Ax(temp1)
            Y = population(m).Y(i - 1) + Ay(temp1)
            Flag = 0

            For j = 0 To i - 1
                If (X = population(m).X(j) And Y = population(m).Y(j)) Then
                    Flag = 1
                    GoTo MyJump1
                End If
            Next j

MyJump1:
            If (Flag = 1) Then
                Flag = 0
                Step2 = 6 - temp1
                Select Case Step2
                    Case 3
                        If Int(Rnd() * 2 + 1) = 1 Then
                            temp2 = 1
                        Else
                            temp2 = 2
                        End If
                    Case 4
                        If Int(Rnd() * 2 + 1) = 1 Then
                            temp2 = 1
                        Else
                            temp2 = 3
                        End If
                    Case 5
                        If Int(Rnd() * 2 + 1) = 1 Then
                            temp2 = 2
                        Else
                            temp2 = 3
                        End If
                End Select

                PresentDirection = temp2
                temp3 = 6 - (temp1 + temp2)
                X = population(m).X(i - 1) + Ax(temp2)
                Y = population(m).Y(i - 1) + Ay(temp2)

                For j = 0 To i - 1
                    If (X = population(m).X(j) And Y = population(m).Y(j)) Then
                        Flag = 1
                        GoTo MyJump2
                    End If
                Next j
MyJump2:
                If (Flag = 1) Then
                    Flag = 0
                    PresentDirection = temp3
                    X = population(m).X(i - 1) + Ax(temp3)
                    Y = population(m).Y(i - 1) + Ay(temp3)
                    For j = 0 To i - 1
                        If (X = population(m).X(j) And Y = population(m).Y(j)) Then
                            Flag = 1
                            ValidFolding = 0
                            GoTo MyJump3

                        End If
                    Next j
                End If
            End If
            PreviousDirection = a(PresentDirection)
            population(m).X(i) = population(m).X(i - 1) + Ax(PresentDirection)
            population(m).Y(i) = population(m).Y(i - 1) + Ay(PresentDirection)
        Next i
MyJump3:
        Return 0
    End Function

    'Random orientation based on 
    Private Function RandomOrientationNewPop(m As Long)
        Dim PreviousDirection, PresentDirection As Long
        Dim i, temp1, temp2, temp3, X, Y, j, Flag, Step2 As Long
        Dim a(0 To 3) As Long
        Dim Ax(0 To 3) As Long
        Dim Ay(0 To 3) As Long

        '                             2            3
        '  Select Direction as:     1 X 0        2 X 1
        '                             3            4
        '
        Dim b(0 To txtProteinLength.Text - 1) As Integer
        Dim c(0 To txtProteinLength.Text - 1) As Integer
        Dim init As genotype
        init.X = b
        init.Y = c
        init.Fitness = 100
        newPopulation(m) = init


        ValidFolding = 1
        newPopulation(m).X(0) = 0
        newPopulation(m).Y(0) = 0
        newPopulation(m).X(1) = 0
        newPopulation(m).Y(1) = 1
        PreviousDirection = 1

        For i = 2 To txtProteinLength.Text - 1
            Select Case PreviousDirection
                Case 1
                    a(1) = 1
                    Ax(1) = 1
                    Ay(1) = 0
                    a(2) = 3
                    Ax(2) = 0
                    Ay(2) = 1
                    a(3) = 4
                    Ax(3) = 0
                    Ay(3) = -1
                Case 2
                    a(1) = 2
                    Ax(1) = -1
                    Ay(1) = 0
                    a(2) = 3
                    Ax(2) = 0
                    Ay(2) = 1
                    a(3) = 4
                    Ax(3) = 0
                    Ay(3) = -1
                Case 3
                    a(1) = 1
                    Ax(1) = 1
                    Ay(1) = 0
                    a(2) = 2
                    Ax(2) = -1
                    Ay(2) = 0
                    a(3) = 3
                    Ax(3) = 0
                    Ay(3) = 1
                Case 4
                    a(1) = 1
                    Ax(1) = 1
                    Ay(1) = 0
                    a(2) = 2
                    Ax(2) = -1
                    Ay(2) = 0
                    a(3) = 4
                    Ax(3) = 0
                    Ay(3) = -1
            End Select

            temp1 = Int(3 * Rnd() + 1)
            PresentDirection = temp1
            temp2 = 0
            temp3 = 0
            X = newPopulation(m).X(i - 1) + Ax(temp1)
            Y = newPopulation(m).Y(i - 1) + Ay(temp1)
            Flag = 0

            For j = 0 To i - 1
                If (X = newPopulation(m).X(j) And Y = newPopulation(m).Y(j)) Then
                    Flag = 1
                    GoTo MyJump1
                End If
            Next j

MyJump1:
            If (Flag = 1) Then
                Flag = 0
                Step2 = 6 - temp1
                Select Case Step2
                    Case 3
                        If Int(Rnd() * 2 + 1) = 1 Then
                            temp2 = 1
                        Else
                            temp2 = 2
                        End If
                    Case 4
                        If Int(Rnd() * 2 + 1) = 1 Then
                            temp2 = 1
                        Else
                            temp2 = 3
                        End If
                    Case 5
                        If Int(Rnd() * 2 + 1) = 1 Then
                            temp2 = 2
                        Else
                            temp2 = 3
                        End If
                End Select

                PresentDirection = temp2
                temp3 = 6 - (temp1 + temp2)
                X = newPopulation(m).X(i - 1) + Ax(temp2)
                Y = newPopulation(m).Y(i - 1) + Ay(temp2)

                For j = 0 To i - 1
                    If (X = newPopulation(m).X(j) And Y = newPopulation(m).Y(j)) Then
                        Flag = 1
                        GoTo MyJump2
                    End If
                Next j
MyJump2:
                If (Flag = 1) Then
                    Flag = 0
                    PresentDirection = temp3
                    X = newPopulation(m).X(i - 1) + Ax(temp3)
                    Y = newPopulation(m).Y(i - 1) + Ay(temp3)
                    For j = 0 To i - 1
                        If (X = newPopulation(m).X(j) And Y = newPopulation(m).Y(j)) Then
                            Flag = 1
                            ValidFolding = 0
                            GoTo MyJump3

                        End If
                    Next j
                End If
            End If
            PreviousDirection = a(PresentDirection)
            newPopulation(m).X(i) = newPopulation(m).X(i - 1) + Ax(PresentDirection)
            newPopulation(m).Y(i) = newPopulation(m).Y(i - 1) + Ay(PresentDirection)
        Next i
MyJump3:
        Return 0
    End Function

    'Sort population to find the best fitness
    'Best fitness indexed at population(0).
    Private Function SortPopByFitness()
        Dim temp As genotype
        For i = 0 To population.Length - 1
            For j = 0 To population.Length - 1
                If (population(i).Fitness < population(j).Fitness) Then
                    temp = population(i)
                    population(i) = population(j)
                    population(j) = temp
                End If

            Next
        Next
        Return 0
    End Function

    'Evaluate function for initial population
    Private Function ComputeInitialFitness(n As Long, sequence As String) As Long
        Dim F, i, j, TestF, TestSeq As Long
        F = 0
        Dim txtHCount = CountH(sequence)

        For i = 0 To sequence.Length - 1
            For j = i + 3 To sequence.Length - 1
                TestSeq = (Math.Abs(HPModel(sequence, i) + HPModel(sequence, j))) '/*Not Sequential */
                If (TestSeq = 2) Then
                    TestF = 0
                    TestF = (Math.Pow((population(n).X(i) - population(n).X(j)), 2)) + Math.Pow((population(n).Y(i) - population(n).Y(j)), 2)
                    If (TestF = 1) Then
                        F = F - 1
                    End If
                End If
            Next j
        Next i

        'population(n).Fitness = F
        'ComputeFullFitnessNewPop = F
        Return F
    End Function

    'Calculates and carries out number of mutations on a population based off mutation rate
    Private Sub MutationHandler(populationSize As Long, sequence As String, mutationRate As Double)
        'Allows the middle of the new population to be mutated
        CurrentPosOfNewPop = Math.Floor(CurrentPosOfNewPop / 2) - 2

        'Ensure random mutation does not happen in the top 20% of the population
        Dim randomMutate = Int(((populationSize - 1) - (populationSize * 0.2) + 1) * Rnd() + (populationSize * 0.2))
        Dim length = populationSize

        Dim randSpot = Int(((sequence.Length - 1) - 2) * Rnd() + 2)

        'Calculate number of mutations needed for a given population
        Dim numMutations As Integer = Math.Floor(length * mutationRate)
        For i = 0 To numMutations

            While (MutateCollision <> 0)
                MutateCollision = 0
                Mutation(randomMutate, randSpot)
            End While
            CurrentPosOfNewPop = CurrentPosOfNewPop + 1
        Next i
    End Sub

    'Conduct mutation based on rotation about a single point on a single random non-elite sequence
    'i as random sequence from pop1. n as middle of sequence for rotation.
    Private Function Mutation(i As Long, n As Integer) As Long
        Dim id As Long
        Dim a As Long
        Dim b As Long
        Dim A_Limit As Long
        Dim choice As Long
        Dim Collision As Long
        Dim dx As Long
        Dim dy As Long
        Dim k As Long
        Dim z As Long
        Dim p As Long
        Dim DummyReturn

        Dim Ary(0 To 2) As Long

        id = CurrentPosOfNewPop

        ' possible rotations 90ß,180ß,270ß
        '           index       1   2    3
        '

        Ary(0) = 1
        Ary(1) = 2
        Ary(2) = 3
        A_Limit = 2

        a = population(i).X(n)          '/* (a, b) rotating point */
        b = population(i).Y(n)

        Do
            Collision = 0
            If (A_Limit > 1) Then
                choice = Int(A_Limit * Rnd() + 1)
            Else
                choice = A_Limit
            End If


            p = Ary(choice)
            For k = choice To A_Limit - 1
                Ary(k) = Ary(k + 1)
            Next k

            A_Limit = A_Limit - 1

            For k = n + 1 To txtProteinLength.Text - 1
                Select Case p

                    Case 1
                        newPopulation(id).X(k) = a + b - population(i).Y(k)       '/* X' = (a+b)-Y  */
                        newPopulation(id).Y(k) = population(i).X(k) + b - a       '/* Y' = (X+b)-a  */
                    Case 2
                        newPopulation(id).X(k) = 2 * a - population(i).X(k)       '/* X' = (2a - X) */
                        newPopulation(id).Y(k) = 2 * b - population(i).Y(k)       '/* Y' = (2b-Y)   */
                    Case 3
                        newPopulation(id).X(k) = population(i).Y(k) + a - b       '/* X' =  Y+a-b   */
                        newPopulation(id).Y(k) = a + b - population(i).X(k)       '/* Y' =  (a+b)-X */
                End Select

                For z = 1 To n

                    If ((newPopulation(id).X(k) = population(i).X(z)) And (newPopulation(id).Y(k) = population(i).Y(z))) Then
                        MutateCollision = 1
                        'MutationInternalFailCount = MutationInternalFailCount + 1
                        'MutationCollisionCount = MutationCollisionCount + 1
                        GoTo MyJump
                    End If
                Next z
            Next k

            If (Collision = 0) Then
                A_Limit = 0
            End If
MyJump:
        Loop Until A_Limit = 0

        If (MutateCollision = 0) Then

            For k = 1 To n
                newPopulation(id).X(k) = population(i).X(k)
                newPopulation(id).Y(k) = population(i).Y(k)
            Next k


            Mutation = 1
        Else
            'MutationFailCount = MutationFailCount + 1
            Mutation = 0
        End If

    End Function

    'Save a selected number of elites based on user input
    Private Sub SaveElites(eliteRate As Double, populationSize As Long)
        Dim length = populationSize
        Dim elitePop As Integer = Math.Floor(length * eliteRate)
        For i = 0 To elitePop
            newPopulation(i) = population(i)
            CurrentPosOfNewPop = CurrentPosOfNewPop + 1
        Next i
    End Sub

    'Handles the number of cross over events to happen and fills remaining population randomly
    Private Sub CrossOverHandler(populationSize As Long, sequence As String, crossOverRate As Double)
        Dim length = populationSize
        Dim upper = sequence.Length - 4
        Dim foldAttempts = 0

        Dim crossOverPop As Integer = Math.Floor(length * crossOverRate)

        For k = 0 To crossOverPop - 1 'Step 2
            Dim randCrossPoint = Int((upper - 3) * Rnd() + 4)
            Dim randSelectionOne = Int(length * Rnd())
            Dim randSelectionTwo = Int(length * Rnd())

            If (CurrentPosOfNewPop <> populationSize - 1) Then
                CurrentPosOfNewPop = CurrentPosOfNewPop + CrossOver(randSelectionOne, randSelectionTwo, randCrossPoint)
            End If
            If (CurrentPosOfNewPop <> populationSize - 1) Then
                CurrentPosOfNewPop = CurrentPosOfNewPop + CrossOver(randSelectionTwo, randSelectionOne, randCrossPoint)
            End If

        Next k


        'If Cross-Over rate < 1 we fill remaining population randomly
        While (CurrentPosOfNewPop <> populationSize)
            ValidFolding = 0
            RandomOrientationNewPop(CurrentPosOfNewPop)
            While (ValidFolding = 0)
                RandomOrientationNewPop(CurrentPosOfNewPop)
            End While
            CurrentPosOfNewPop = CurrentPosOfNewPop + 1
        End While
    End Sub

    Private Function CrossOver(i As Long, j As Long, n As Integer)
        'CrossOver i,j = ith and jth polulation, n = cross point
        'First part of i and 2nd part of j.
        'Return: 1 => Success, 0=> Failure
        Dim PrevDirection, k, z, p As Long
        Dim temp1, temp2, temp3, Collision, dx, dy, Step2 As Long
        Dim id As Long
        Dim crossOvr As Integer = 0

        Dim a(0 To 3) As Long
        Dim Ax(0 To 3) As Long
        Dim Ay(0 To 3) As Long

        Dim b(0 To txtProteinLength.Text - 1) As Integer
        Dim c(0 To txtProteinLength.Text - 1) As Integer
        Dim init As genotype
        init.X = b
        init.Y = c
        init.Fitness = 100
        newPopulation(CurrentPosOfNewPop) = init
        id = CurrentPosOfNewPop

        '/* Detect Previous Direction */
        If (population(i).X(n) = population(i).X(n - 1)) Then
            p = population(i).Y(n - 1) - population(i).Y(n)
            If (p = 1) Then
                PrevDirection = 3
            Else
                PrevDirection = 4
            End If

        Else
            p = population(i).X(n - 1) - population(i).X(n)
            If (p = 1) Then
                PrevDirection = 1
            Else
                PrevDirection = 2
            End If
        End If


        Select Case PrevDirection
            Case 1
                Ax(0) = -1
                Ay(0) = 0
                Ax(1) = 0
                Ay(1) = 1
                Ax(2) = 0
                Ay(2) = -1
            Case 2
                Ax(0) = 1
                Ay(0) = 0
                Ax(1) = 0
                Ay(1) = 1
                Ax(2) = 0
                Ay(2) = -1
            Case 3
                Ax(0) = 1
                Ay(0) = 0
                Ax(1) = -1
                Ay(1) = 0
                Ax(2) = 0
                Ay(2) = -1

            Case 4
                Ax(0) = 1
                Ay(0) = 0
                Ax(1) = -1
                Ay(1) = 0
                Ax(2) = 0
                Ay(2) = 1
        End Select

        temp1 = Int(3 * Rnd() + 1)

        newPopulation(id).X(n + 1) = population(i).X(n) + Ax(temp1)
        newPopulation(id).Y(n + 1) = population(i).Y(n) + Ay(temp1)
        Collision = 0

        dx = newPopulation(id).X(n + 1) - population(j).X(n + 1)
        dy = newPopulation(id).Y(n + 1) - population(j).Y(n + 1)

        For k = n + 1 To txtProteinLength.Text - 1
            newPopulation(id).X(k) = population(j).X(k) + dx

            newPopulation(id).Y(k) = population(j).Y(k) + dy

            For z = 0 To n
                If ((newPopulation(id).X(k) = population(i).X(z)) And (newPopulation(id).Y(k) = population(i).Y(z))) Then
                    Collision = 1
                    '  CrossoverInternalFailCount = CrossoverInternalFailCount + 1
                    'CrossoverCollisionCount = CrossoverCollisionCount + 1
                    GoTo MyOut1
                End If
            Next z
        Next k

MyOut1:
        If (Collision = 1) Then         '/* ======> Second try ==== */
            Collision = 0
            Step2 = 6 - temp1
            Select Case Step2
                Case 3
                    If Int(Rnd() * 2 + 1) = 1 Then
                        temp2 = 1
                    Else
                        temp2 = 2
                    End If

                Case 4
                    If Int(Rnd() * 2 + 1) = 1 Then
                        temp2 = 1
                    Else
                        temp2 = 3
                    End If

                Case 5
                    If Int(Rnd() * 2 + 1) = 1 Then
                        temp2 = 2
                    Else
                        temp2 = 3
                    End If
            End Select

            temp3 = 6 - (temp1 + temp2)
            newPopulation(id).X(n + 1) = population(i).X(n) + Ax(temp2)
            newPopulation(id).Y(n + 1) = population(i).Y(n) + Ay(temp2)
            dx = newPopulation(id).X(n + 1) - population(j).X(n + 1)
            dy = newPopulation(id).Y(n + 1) - population(j).Y(n + 1)

            For k = n + 1 To txtProteinLength.Text - 1

                newPopulation(id).X(k) = population(j).X(k) + dx
                newPopulation(id).Y(k) = population(j).Y(k) + dy

                For z = 0 To n
                    If ((newPopulation(id).X(k) = population(i).X(z)) And (newPopulation(id).Y(k) = population(i).Y(z))) Then
                        Collision = 1
                        'CrossoverCollisionCount = CrossoverCollisionCount + 1
                        '    CrossoverInternalFailCount = CrossoverInternalFailCount + 1
                        GoTo MyOut2
                    End If
                Next z
            Next k

MyOut2:
            If (Collision = 1) Then
                Collision = 0
                newPopulation(id).X(n + 1) = population(i).X(n) + Ax(temp3)
                newPopulation(id).Y(n + 1) = population(i).Y(n) + Ay(temp3)
                dx = newPopulation(id).X(n + 1) - population(j).X(n + 1)
                dy = newPopulation(id).Y(n + 1) - population(j).Y(n + 1)

                For k = n + 1 To txtProteinLength.Text - 1
                    newPopulation(id).X(k) = population(j).X(k) + dx
                    newPopulation(id).Y(k) = population(j).Y(k) + dy
                    For z = 0 To n
                        If ((newPopulation(id).X(k) = population(i).X(z)) And (newPopulation(id).Y(k) = population(i).Y(z))) Then
                            Collision = 1
                            '    CrossoverInternalFailCount = CrossoverInternalFailCount + 1
                            'CrossoverCollisionCount = CrossoverCollisionCount + 1
                            GoTo MyOut3
                        End If
                    Next z
                Next k
            End If '/* 3rd try if ends */
        End If '/* 2nd try if ends */

MyOut3:
        '   CrossoverSuccessCount = CrossoverSuccessCount + 1
        For k = 0 To n
                newPopulation(id).X(k) = population(i).X(k)
                newPopulation(id).Y(k) = population(i).Y(k)
            Next k

        crossOvr = CalculateThePath(i, n, id) ' if successful should return 1 else 0

        Return crossOvr
    End Function

    Function CalculateThePath(i As Long, n As Integer, id As Long)
        Dim correctPath = 1
        Dim k, z

        For k = 0 To txtProteinLength.Text - 1
            For z = k + 1 To txtProteinLength.Text - 1
                If ((newPopulation(id).X(k) = newPopulation(id).X(z)) And (newPopulation(id).Y(k) = newPopulation(id).Y(z))) Then
                    correctPath = 0
                End If

            Next z
        Next k

        Return correctPath
    End Function

    'Verify whether or not the currently indexed amino acid is hydrophobic
    Private Function HPModel(sequence As String, index As Long)
        Dim modelResult = 0
        Dim isH = "h"
        If (sequence(index) = isH) Then
            modelResult = 1
        End If
        Return modelResult
    End Function

    '******************************************************************'
    'Find below a collection of methods that convert the user input into a best fitness array 
    ' as well as an amino acid array. 

    Private Function TrimArray(needsTrim As String())
        Dim searchChar As String = "="
        Dim equalPos As Integer
        Dim trimmed(13) As String
        For i As Integer = 0 To needsTrim.Length - 1
            equalPos = InStr(1, needsTrim(i), searchChar, CompareMethod.Binary)
            trimmed(i) = needsTrim(i).Remove(0, equalPos)

        Next

        Return trimmed
    End Function

    Private Function CreateAminoArray(inputList As List(Of String))
        Dim index = inputList.Count
        Dim aminoArray(13) As String
        Dim j As Integer = 0
        For i As Integer = 0 To index - 1 Step 2
            aminoArray(j) = inputList.ElementAt(i)
            j = j + 1
        Next
        aminoArray = TrimArray(aminoArray)
        Return aminoArray
    End Function

    Private Function CreateFitnessArray(inputList As List(Of String))
        Dim index = inputList.Count
        Dim fitnessArray(13) As String
        Dim j As Integer = 0
        For i As Integer = 1 To index Step 2
            fitnessArray(j) = inputList.ElementAt(i)
            j = j + 1
        Next
        fitnessArray = TrimArray(fitnessArray)
        Return fitnessArray
    End Function

    Private Function RemoveWhitespace(fullString As String) As String
        Return New String(fullString.Where(Function(x) Not Char.IsWhiteSpace(x)).ToArray())
    End Function

    Private Function ReadInput()
        Dim FileNum As Integer = FreeFile()
        Dim inputLocation As String = GetInputLocation()
        Dim TempL As String
        FileOpen(FileNum, inputLocation, OpenMode.Input)
        Dim lineHolder As New List(Of String)()

        Dim i As Integer = 0
        Do Until EOF(FileNum)
            TempL = LineInput(FileNum)
            TempL = RemoveWhitespace(TempL)
            lineHolder.Add(TempL)
            i = i + 1
        Loop

        FileClose(FileNum)
        Return lineHolder
    End Function

    Private Function CountH(sequence As String)
        Dim hCount = 0
        Dim h As Char = "h"
        For i = 0 To sequence.Length - 1
            If sequence.ElementAt(i) = h Then
                hCount = hCount + 1
            End If
        Next
        Return hCount
    End Function

    '********************************************************************'
    'Find below a collection of functions that collect important information from the GUI.

    Private Function GetPopulationSize()
        Dim populationSize As Double = txtPopulationSize.Text
        Return populationSize
    End Function

    Private Function GetEliteRate()
        Dim eliteRate As Double = txtEliteRate.Text
        Return eliteRate
    End Function

    Private Function GetCrossOverRate()
        Dim crossOverRate As Double = txtCrossOverRate.Text
        Return crossOverRate
    End Function

    Private Function GetMutationRate()
        Dim mutationRate As Double = txtMutationRate.Text
        Return mutationRate
    End Function

    Private Function GetProteinLength()
        Dim proteinLength As Integer = txtProteinLength.Text
        Return proteinLength
    End Function

    Private Function GetTargetValue()
        Dim populationSize As Integer = txtPopulationSize.Text
        Return populationSize
    End Function

    Private Function GetMaximumIteration()
        Dim maximumIteration As Long = txtMaximumIteration.Text
        Return maximumIteration
    End Function

    Private Function GetInputLocation()
        Dim location As String = txtInputLocation.Text
        Return location
    End Function

    '********************************************************************'
    'Find a collection of functions that help the drawing process
    Sub AddBestCollection(i As Long, drawingAmount As Long, maxIterations As Long)
        Dim iterateDistance = Math.Floor(maxIterations / drawingAmount)
        Dim testI = i
        While (testI >= 0)
            If testI = 0 Then
                bestCollection(bestCollectionIncrement) = population(0)
                bestCollectionIncrement = bestCollectionIncrement + 1
            ElseIf i = maxIterations Then
                bestCollection(bestCollectionIncrement) = population(0)
                bestCollectionIncrement = bestCollectionIncrement + 1
            End If
            testI = testI - iterateDistance
        End While
    End Sub

    'Find below the draw function.
    Function DrawTheBestFolding(i As Long, sequence As String)
        Dim dx As Long
        Dim dy As Long
        Dim dx1 As Long
        Dim dy1 As Long
        Dim dx2 As Long
        Dim dy2 As Long

        Dim massx As Double
        Dim massy As Double
        Dim Area As Double
        Dim txtHCount = CountH(sequence)

        Dim GraphUnit As Long
        Dim SmallLength As Long
        Dim k As Long

        Dim penRed As New System.Drawing.Pen(Color.Red, 3)
        Dim penGreen As New System.Drawing.Pen(Color.Green, 3)
        Dim penBlack As New System.Drawing.Pen(Color.Black, 3)
        Dim penBlue As New System.Drawing.Pen(Color.Blue, 3)

        Dim graphic As System.Drawing.Graphics
        PictureBox1.Refresh()
        graphic = PictureBox1.CreateGraphics

        dx = PictureBox1.Width / 3 + 50
        dy = PictureBox1.Height / 2 '- PictureBox1.Height + 140

        SmallLength = PictureBox1.Width

        If SmallLength > PictureBox1.Height Then
            SmallLength = PictureBox1.Height
        End If

        SmallLength = (SmallLength - 200) '/ 2
        GraphUnit = SmallLength / sequence.Length

        GraphUnit = GraphUnit + 15


        lblFitness1.Text = "Fitness: " + Str(bestCollection(i).Fitness) + "/" + Str(txtTargetValue.Text)
        lblFitness1.Refresh()
        lblDrawing1.Text = "Drawing: " + Str(CurrentPositionOfBestCollection + 1) + "/" + Str(bestCollection.Length)
        lblDrawing1.Refresh()

        If (HPModel(sequence, i) <> 0) Then
            'graphic.DrawEllipse(penRed, dx, dy, 10, 10)

        Else
            ' graphic.DrawEllipse(penGreen, dx, dy, 10, 10)
        End If

        dx1 = dx
        dy1 = dy

        For k = 0 To sequence.Length - 1
            dx2 = bestCollection(i).X(k) * GraphUnit + dx
            dy2 = bestCollection(i).Y(k) * GraphUnit + dy
            If (HPModel(sequence, k) <> 0) Then
                graphic.DrawEllipse(penRed, dx2, dy2, 10, 10)
            Else
                graphic.DrawEllipse(penGreen, dx2, dy2, 10, 10)
            End If
            graphic.DrawLine(penBlack, dx1, dy1, dx2, dy2)

            dx1 = dx2
            dy1 = dy2

        Next k

        ' Draw the Centre of mass
        massx = 0
        massy = 0
        For k = 1 To sequence.Length - 1

            massx = massx + bestCollection(i).X(HPModel(sequence, k))
            massy = massy + bestCollection(i).Y(HPModel(sequence, k))
            '
        Next k
        massx = massx / (txtHCount)
        massy = massy / (txtHCount)


        graphic.DrawEllipse(penBlue, CType(massx * GraphUnit + dx, Single), CType(massy * GraphUnit + dy, Single), 5, 5)
        Return 0
    End Function

    Private Sub btnNextSequence_Click(sender As Object, e As EventArgs) Handles btnNextSequence.Click
        CurrentPositionOfInput = CurrentPositionOfInput + 1
        If (CurrentPositionOfInput >= EndPositionOfInput) Then
            CurrentPositionOfInput = 0
            'lblSequence1.Text = "Sequence: " + CurrentPositionOfInput + "/" + EndPositionOfInput
        End If
        lblSequence1.Text = "Sequence: " + Str(CurrentPositionOfInput + 1) + "/" + Str(EndPositionOfInput)
    End Sub

    Private Sub btnNextDrawing_Click(sender As Object, e As EventArgs) Handles btnNextDrawing.Click
        Dim input As New List(Of String)()
        input = ReadInput()
        'Dim fitnessArray = CreateFitnessArray(input)
        Dim aminoArray = CreateAminoArray(input)
        CurrentPositionOfBestCollection = CurrentPositionOfBestCollection + 1
        If (CurrentPositionOfBestCollection >= bestCollection.Length) Then
            CurrentPositionOfBestCollection = 0
        End If
        DrawTheBestFolding(CurrentPositionOfBestCollection, aminoArray(CurrentPositionOfInput))
    End Sub


End Class
