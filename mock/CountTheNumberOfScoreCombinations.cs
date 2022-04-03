namespace ElementsOfProgrammingInterviews
{
public class ScoreCombinations
{
	public uint GetNumberOfCombinations(uint finalScore, uint[] nominalScores) // TEST: finalScore=5, nominalScores = {3,2}, combinations=1
	{
		// TODO: argument check
		var minScore = nominalScores.Min();
		if (minScore<=0) throw new ArgumentException(nameof(nominalScores), "Only positive scores are allowed"); 
		// TODO: be careful about type conversions

		if (nominalScores.Length==1)
		{
			var singleElement = nominalScores[0];
			var remainder = finalScore % singleElement;
			if (remainder ==0) return 1;
			return 0;
		}		
		uint combinations = 0;
		
		// TODO: verify if we need nominalScores to be sorted
		// Assumption: nominalScores does not have dupicates
		
		for (j=0; j<nominalScores.Length; i++)
		{
			var score = nominalScores[j]; // 3 
			var maxNumberOfOccurrences = finalScore / score; // 1 
			var remainder = finalScore % score; // modulo, remainder
			if (remainder>0 && nominalScores.Length == 1) return 0; // Non-divisable 

			if (maxNumberOfOccurrences==0) continue; // this element does not occur - TODO- refactor -clumsy

			for (var i=0; i<=maxNumberOfOccurrences; i++) // TODO: check boundary condition // 0,1
			{
				// construct a structured way to enumerate score combinations
				var remainingScore = finalScore - i * score; //2
				var remainingNominalScores = nominalScores.ToList().RemoveAt(j); // copy and remove element - best to start at the end! // {2}
				var numberOfCombinations = GetNumberOfCombinations(remainingScore, remainingNominalScores); 
				combinations+=numberOfCombinations; // TODO: verify, not sure
			}
			
		}

		return combinations;
		
	}



}



}