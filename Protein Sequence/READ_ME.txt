Protein Sequence Folding

Austin Schmidt
9/14/2019

WHAT IS THIS PROJECT:

	This app is a simple example of a genetic algorithm that runs on a selection of input protein sequences.
	User input for population size, mutation rate, cross-over rate, etc. are adjustable by the user.


HOW TO RUN:

	1. Create an input file that has the following formatting:
		
			Sequence = hhpphphpphp
			Fitness = -6
			Sequence = hhhhppphppphphhpphhp 
			Fitness = -21
					.
					.
					.

		The attached input file is formatted with 14 sequences.
	
	2. Select file path for selected input file in the provided space.
	
	3. Adjust genetic algorithm settings as desired. There is no exception handling in place for errors.
	   Extreem values are cautioned against for program stability.

	4. Select the Start button and wait for completion of the set generation amount.

	5. The best sequence for each generation in intervals, based on the Drawing Amount field, is saved.
	   Selecting the Next Drawing button allows easy navigation between drawings.

	6. When ready, select Next Sequence then Start to continue with other sequences.