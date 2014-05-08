using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cobra.SpellCheck
{
	public class EditDistance
	{
		public string Source { set; get; }
		public string Destination { set; get; }

		private int[][] Matrix;

		public int[][] GetResultingMatrix()
		{
			return Matrix;
		}

		public int CalculateEditDistance(string m_Source, string m_Destination)
		{
			Source = m_Source;
			Destination = m_Destination;

			InitMatrix();

			ComputeDistance();

			return Matrix[Source.Length][Destination.Length];
		}

		private void ComputeDistance()
		{
			for (int i = 1; i < Source.Length + 1; i++)
			{
				for (int j = 1; j < Destination.Length + 1; j++)
				{
					Matrix[i][j] = MinDistance(i,j);
				}
			}
		}

		private int MinDistance(int i, int j)
		{
			bool SameChar=false;
			int CrossValue=0;
			int LeftValue = 0;
			int TopValue = 0;

			if( Source[i-1]==Destination[j-1])
				SameChar = true;

			CrossValue = SameChar == true ? Matrix[i - 1][j - 1] : Matrix[i - 1][j - 1]+1;

			LeftValue = Matrix[i - 1][j] + 1;

			TopValue = Matrix[i][j - 1]+1;

			if (LeftValue < TopValue)
			{				
				if (LeftValue < CrossValue)
				{
					return LeftValue;
				}
				else
					return CrossValue;
			}
			else
			{
				if (TopValue < CrossValue)
				{
					return TopValue;
				}
				else
					return CrossValue;
			}
			
		}

		private void InitMatrix()
		{
			Matrix = new int[Source.Length + 1][];



			// Initialize Double Dimension Array
			for (int i = 0; i < Source.Length+1; i++)
			{
				Matrix[i] = new int[Destination.Length + 1];
				Matrix[i][0] = i;				
			}

			for (int j = 0; j < Destination.Length+1; j++)
			{
				Matrix[0][j] = j;
			}

			// Initalize Starting elements


		}

	}
}
