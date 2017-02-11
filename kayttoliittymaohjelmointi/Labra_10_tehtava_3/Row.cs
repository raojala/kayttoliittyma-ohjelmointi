using System;
using System.Linq;

namespace Labra_10_tehtava_3
{
	public class Row
	{
		int[] numbers, stars;

        public int[] Numbers
        {
            get { return numbers; }
        }

        public int[] Stars
        {
            get { return stars; }
        }

        public Row(int lengthPerRow, int min, int max, Random rand)
		{
            try
            {
                // generate one number, and check it's duplicates
                numbers = new int[lengthPerRow];
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = CreateAndCheckDuplicates(numbers, min, max, rand);
                }
                Array.Sort(numbers);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Row(int lengthPerRow, int min, int max, Random rand, int starnumbers, int starslength) : this(lengthPerRow, min, max, rand)
        {
            try
            {
                stars = new int[starslength];
                for (int i = 0; i < stars.Length; i++)
                {
                    stars[i] = CreateAndCheckDuplicates(stars, min, starnumbers, rand);
                }
                Array.Sort(stars);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // method that creates a number, then checks it against excisting numbers in an array 
        // and keeps creating new number until you get one thats not in the list.
        public int CreateAndCheckDuplicates(int[] arrayToCheck, int min, int max, Random rand)
        {
            try
            {
                int number = rand.Next(min, max);

                // use LINQ to  check if the array contains the random number.
                while (arrayToCheck.Contains(number))
                {
                    number = rand.Next(min, max);
                }
                return number;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
