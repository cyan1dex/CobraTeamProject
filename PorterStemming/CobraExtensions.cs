using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cobra.PorterStemming
{
	public static class CobraExtensions
	{
		/// <summary>
		/// This function will return the measure of any string
		/// it will computer (VC) pattern count, and will return the count.
		/// C= Consonant
		/// V= Vowel
		/// </summary>
		/// <param name="ProcessingString"></param>
		/// <returns></returns>
		public static int Measure(this String ProcessingString)
		{

			int VCCount = 0;

			ProcessingString = ProcessingString.VowelPattern();
			StringBuilder sbCV = new StringBuilder(ProcessingString.Length);

			sbCV.Append(ProcessingString);

			
			
			// Once we get CV pattern, we can commute the measure.
			for (int i = 0; i < sbCV.Length; i++)
			{
				int NextPos=i+1;

				if (NextPos >= sbCV.Length) break;

				if(sbCV[i]==sbCV[NextPos])
				{
					sbCV.Remove(i, 1);
						i--;
				}

			}

			sbCV.Append(" ");

			ProcessingString = sbCV.ToString() ;

			for (int i = 0; i < ProcessingString.Length-1; i++)
			{
				if (ProcessingString.Substring(i, 2) == "VC")
					VCCount++;
			}

			return VCCount;
		}

		public static Boolean VowelExist(this String ProcessingString)
		{
			ProcessingString = ProcessingString.VowelPattern();

			if (ProcessingString.IndexOf('V') >= 0)
				return true;
			else
				return false;
		}

		public static string Right(this String ProcessingString, int Count)
		{
			if (Count > ProcessingString.Length)
				return string.Empty;

			return ProcessingString.Substring(ProcessingString.Length - Count);
		}

		

		public static string VowelPattern(this String ProcessingString)
		{
			StringBuilder sbCV = new StringBuilder(ProcessingString.Length);
			
			for (int i = 0; i < ProcessingString.Length; i++)
			{
				switch (ProcessingString[i])
				{
					case 'a':
					case 'e':
					case 'i':
					case 'o':
					case 'u':

						sbCV.Append("V");
						break;

					case 'y':

						if (IsNextVowel(ProcessingString, sbCV.Length + 1))
							sbCV.Append("V");
						else
							sbCV.Append("C");

						break;

					default:

						sbCV.Append("C");
						break;

				}
			}

			return sbCV.ToString();
		}

		/// <summary>
		/// Helper function the check is next 
		/// </summary>
		/// <param name="ProcessingString"></param>
		/// <param name="Position"></param>
		/// <returns></returns>
		private static Boolean IsNextVowel(string ProcessingString, int Position)
		{

			if (Position >= ProcessingString.Length) 
				return false;

			if (ProcessingString[Position] == 'a' || ProcessingString[Position] == 'e' ||
				ProcessingString[Position] == 'i' || ProcessingString[Position] == 'o' ||
				ProcessingString[Position] == 'u'
				)
				return true;
			else
				return false;
		}

	
	}
}
