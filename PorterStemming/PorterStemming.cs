using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cobra.PorterStemming
{
	/// <summary>
	/// Module for Porter Stemming Algorithum
	/// </summary>
	public class PorterStemming
	{
		
        //#region Constructors

        //public PorterStemming(String InputString)
        //{
        //    this.InputString = InputString;
        //    // start the processing of stemming;
        //    PorterStemmingProcessing();
        //}

        //#endregion

        // Public Property InputString 
        
        private String m_InputString;

        public String InputString
        {
            get { return m_InputString; }
            set
            {
                m_InputString = value;
                ProcessingString = value;

            }
        }

		#region Properties


		public void PorterStemmingProcessing(string inputString)
		{

            InputString = inputString;

			bool result = false;
			bool result2 = false;
			bool result3 = false;
			bool result4 = false;
			bool result5 = false;

			PorterStep1a();
			PorterStep1b();
			PorterStep1c();

			do
			{
				result2 = PorterStep2();
				result3 = PorterStep3();
				result4 = PorterStep4();
				result5 = PorterStep5();

				if (result2 || result3 || result4 || result5)
					result = true;
				else
					result = false;
			}
			while (result);

		}

		
		// Private Property ProcessingString
		private String m_ProcessingString=string.Empty;

		public string ProcessingString
		{
			get { return m_ProcessingString; }
			set
			{
				m_ProcessingString = value;
				ProcessingStrLen = m_ProcessingString.Length;
			}
 
		}

		private int ProcessingStrLen;
		

		#endregion


		#region AlgoFunctions

		private bool PorterStep1a()
		{
			// Rule 1 SSES -> SS
			if (ProcessingString.Right(4) == "sses")
			{
				ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 1);			
				return true;
			}
			// Rule 2 IES -> I
			else if (ProcessingString.Right(3) == "ies")
			{
				ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 2);
				return true;
			}

				// Rule SS -> SS
			else if (ProcessingString.Right(2) == "ss")
			{
				return true;				
			}

			// Rule 3 S->
			else if (ProcessingString.Right(1) == "s")
			{
				ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 1);
				return true;
			}
			
			return false;	
		}

		private bool PorterStep1b()
		{
			// rule 1  (m>0)EED -> EE
			if (ProcessingString.Right(3) == "eed"
					&& ProcessingString.Substring(0, ProcessingStrLen - 3).Measure() > 0)
			{
				ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 1);
				return true;
			}
			//rule 2 (v*)ED ->
			else if (ProcessingString.Right(2) == "ed")
			{
				if (ProcessingString.Substring(0, ProcessingStrLen - 2).VowelExist())
				{
					ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 2);
					PorterStep1bStar();
					return true;
				}
			}
			//rule 3 (v*)ing ->
			else if (ProcessingString.Right(3) == "ing")
			{
				if (ProcessingString.Substring(0, ProcessingStrLen - 3).VowelExist())
				{
					ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 3);
					PorterStep1bStar();
					return true;
				}
			}
				return false;
			
		}


		private bool PorterStep1bStar()
		{

			string  tmpString = ProcessingString.Right(2);

			if (tmpString == "at" || tmpString == "bl" || tmpString =="iz")				
			{
				ProcessingString = ProcessingString + "e";
				return true;
			}
			else if(tmpString[0]==tmpString[1] && !(tmpString[1]=='l' || tmpString[1]=='s' || tmpString[1]=='z'))
			{
				ProcessingString = ProcessingString.Substring(0, ProcessingStrLen-1);
				return true;
			}
			else if (ProcessingString.Substring(0, ProcessingStrLen - 1).Measure() == 1)
			{
				if (ProcessingString.Substring(0, ProcessingStrLen - 1).VowelPattern().Substring(ProcessingStrLen - 3) == "CVC")
				{
					tmpString = ProcessingString.Substring(ProcessingStrLen - 1);
					if (tmpString.Equals("w") || tmpString.Equals("x") || tmpString.Equals("y"))
					{
						ProcessingString = ProcessingString + "e";
						return true;
					}
				}
			}
			return false;
		}

		private bool PorterStep1c()
		{
			if (ProcessingStrLen <= 0) return false;

			if (ProcessingString[ProcessingStrLen-1]=='y' && ProcessingString.Substring(0, ProcessingStrLen - 1).VowelExist())
			{
				ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 1) + "i";
				return true;
			}

			return false;
		}

		private bool PorterStep2()
		{
			int measure=0;

			if (ProcessingStrLen - 7 > 0)
				measure = ProcessingString.Substring(0, ProcessingStrLen - 7).Measure();

			if (measure > 0)
			{
				if (ProcessingString.Right(7) == "ational")
				{
					ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 7) + "ate";
					return true;
				}
				else if (ProcessingString.Right(7) == "ization")
				{
					ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 7) + "ize";
					return true;
				}
				else if (ProcessingString.Right(7) == "iveness")
				{
					ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 7) + "ive";
					return true;
				}
				else if (ProcessingString.Right(7) == "fulness")
				{
					ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 7) + "ful";
					return true;
				}
				else if (ProcessingString.Right(7) == "ousness")
				{
					ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 7) + "ous";
					return true;
				}

				measure = 0;
			}


			if (ProcessingStrLen - 6 > 0)
				measure = ProcessingString.Substring(0, ProcessingStrLen - 6).Measure();

			if (measure > 0)
			{
				if (ProcessingString.Right(6) == "tional")
				{
						ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 6) + "tion";
						return true;
				}
				else if (ProcessingString.Right(6) == "biliti")
				{
					ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 6) + "ble";
					return true;
				}

				measure = 0;
			}


			if (ProcessingStrLen - 5 > 0)
				measure = ProcessingString.Substring(0, ProcessingStrLen - 5).Measure();

			if (measure > 0)
			{
					if (ProcessingString.Right(5) == "entli")
					{
						ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 5) + "ent";
						return true;
					}
					else if (ProcessingString.Right(5) == "ousli")
					{
						ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 5) + "ous";
						return true;
					}

					else if (ProcessingString.Right(5) == "ation")
					{
						ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 5) + "ate";
						return true;
					}
					else if (ProcessingString.Right(5) == "alism")
					{
						ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 5) + "al";
						return true;
					}

					else if (ProcessingString.Right(5) == "aliti")
					{
						ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 5) + "al";
						return true;
					}
					else if (ProcessingString.Right(5) == "aviti")
					{
						ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 5) + "ive";
						return true;
					}
					measure = 0;
			}

			if (ProcessingStrLen - 4 > 0)
				measure = ProcessingString.Substring(0, ProcessingStrLen - 4).Measure();

			if (measure > 0)
			{
					if (ProcessingString.Right(4) == "enci")
					{
						ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 4) + "ence";
						return true;
					}
					else if (ProcessingString.Right(4) == "anci")
					{
						ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 4) + "ance";
						return true;
					}
					else if (ProcessingString.Right(4) == "izer")
					{
						ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 4) + "ize";
						return true;
					}
					else if (ProcessingString.Right(4) == "abli")
					{
						ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 4) + "able";
						return true;
					}
					else if (ProcessingString.Right(4) == "alli")
					{
						ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 4) + "al";
						return true;
					}

					measure = 0;
			}


			if (ProcessingStrLen - 3 > 0)
				measure = ProcessingString.Substring(0, ProcessingStrLen - 3).Measure();

			if (measure > 0)
			{
				
				if (ProcessingString.Right(3) == "eli")
				{
					ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 3) + "e";
					return true;
				}

				else if (ProcessingString.Right(4) == "ator")
				{
					ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 4) + "ate";
					return true;
				}
		
			}	

		
			return false;	
		}

		private bool PorterStep3()
		{
			//int measure3 = ProcessingString.Substring(0, ProcessingStrLen - 3).Measure();
			//int measure4 = ProcessingString.Substring(0, ProcessingStrLen - 4).Measure();

			int measure=0;

			if (ProcessingStrLen - 5 > 0)
				measure = ProcessingString.Substring(0, ProcessingStrLen - 5).Measure();

			if (measure > 0)
			{
				if (ProcessingString.Right(5) == "icate")
				{
					ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 5) + "ic";
					return true;
				}
				else if (ProcessingString.Right(5) == "ative")
				{
					ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 5);
					return true;
				}
				else if (ProcessingString.Right(5) == "alize")
				{
					ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 5) + "al";
					return true;
				}
				else if (ProcessingString.Right(5) == "iciti")
				{
					ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 5) + "ic";
					return true;
				}
				measure = 0;
			}

			if (ProcessingStrLen - 4 > 0)
				measure = ProcessingString.Substring(0, ProcessingStrLen - 4).Measure();

			if (measure > 0)
			{
				if (ProcessingString.Right(4) == "ical")
				{
					ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 4) + "ic";
					return true;
				}
				else if (ProcessingString.Right(4) == "ness")
				{
					ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 4);
					return true;
				}
				measure = 0;
			}

			if (ProcessingStrLen - 3 > 0)
				measure = ProcessingString.Substring(0, ProcessingStrLen - 3).Measure();

			if (measure > 0)
			{
					if (ProcessingString.Right(3) == "ful")
					{
						ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 3);
						return true;
					}
			}

		
		
			return false;
		}

		private bool PorterStep4()
		{

			int measure = 0;

			if (ProcessingStrLen - 5 > 0)
				measure = ProcessingString.Substring(0, ProcessingStrLen - 5).Measure();

			if (measure>=2)
			{
				
				if (ProcessingString.Right(5) == "ement")
				{
					ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 5);
					return true;
				}
				measure=0;
			}

			if (ProcessingStrLen - 4 > 0)
				measure = ProcessingString.Substring(0, ProcessingStrLen - 4).Measure();

			if (measure >= 2)
			{
				string tmpMeasure = ProcessingString.Right(4);

				if (tmpMeasure == "ance" || tmpMeasure == "ence" || tmpMeasure == "able" || tmpMeasure == "ible" || tmpMeasure == "ment")
				{
					ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 4);
					return true;
				}

				measure=0;
			}

			if (ProcessingStrLen - 3 > 0)
				measure = ProcessingString.Substring(0, ProcessingStrLen - 3).Measure();

			if (measure >= 2)
			{
				string tmpMeasure = ProcessingString.Right(3);

				if (tmpMeasure == "ant" || tmpMeasure == "ent" || tmpMeasure == "ion" || tmpMeasure =="ism" || tmpMeasure =="ate" || tmpMeasure=="iti" || tmpMeasure=="ous" || tmpMeasure=="ive" || tmpMeasure=="ize")
				{
					ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 3);
					return true;
				}

				measure=0;
			}

			if (ProcessingStrLen - 2 > 0)
				measure = ProcessingString.Substring(0, ProcessingStrLen - 2).Measure();

			if(measure>=2)
			{
				string tmpMeasure = ProcessingString.Right(2);

				if (tmpMeasure== "al" ||  tmpMeasure == "er" || tmpMeasure == "ic")
				{
					ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 2);
					return true;
				}		
			}

				
			
			return false;
		}

		private bool PorterStep5()
		{
			if (ProcessingStrLen <= 0) return false;

			int measure = ProcessingString.Substring(0, ProcessingStrLen - 1).Measure();

			if (measure >= 2 && ProcessingString.Right(1)=="e")
			{
				ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 1);
				return true;
			}
			else if (measure == 1 && ProcessingString.Right(1) == "e")
			{
				if (ProcessingStrLen >= 4)
				{

					if (ProcessingString.Substring(0, ProcessingStrLen - 1).VowelPattern().Substring(ProcessingStrLen - 4) == "CVC")
					{
						string tmpString = ProcessingString.Substring(ProcessingStrLen - 1);
						if (tmpString == "w" || tmpString == "x" || tmpString == "y")
						{
							ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 1);
							return true;
						}
					}
					else
					{
						ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 1);
						return true;
					}
				}
				else
				{
					ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 1);
					return true;
				}
			}
			else if (measure == 2 && ProcessingString.Right(2) == "ll")
			{
				ProcessingString = ProcessingString.Substring(0, ProcessingStrLen - 1);
				return true;
			}

			return false;
		}

		#endregion
	}
}

