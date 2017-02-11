using System;
using System.Collections.Generic;

namespace Labra_10_tehtava_3
{
	public class Game
	{
		public enum GameTypes
        {
            Lotto,
            VikingLotto,
            EuroJackpot
        }

		public List<Row> Rows
		{
			get
			{
                return rows;
			}
		}

		public Game(GameTypes game, int numberOfRows)
		{
            try
            {
                rows = new List<Row>();
                int numbers = 0, maxNumber = 0;
                // set the maximum number of numbers generated for the row
                switch (game)
                {
                    case GameTypes.Lotto:
                        numbers = ROWLENGTHLOTTO;
                        maxNumber = MAXNUMBERLOTTO;
                        break;
                    case GameTypes.VikingLotto:
                        numbers = ROWLENGTHVIKINGLOTTO;
                        maxNumber = MAXNUMBERVIKINGLOTTO;
                        break;
                    case GameTypes.EuroJackpot:
                        numbers = ROWLENGTHEUROJACKPOT;
                        maxNumber = MAXNUMBEREUROJACKPOT;
                        break;
                }

                Random rand = new Random();
                for (int i = 0; i < numberOfRows; i++)
                {
                    if (!(game == GameTypes.EuroJackpot))
                    {
                        // create a row and input length of the row, maxnumber + 1 (rand ignores set highest) and random. 
                        rows.Add(new Row(numbers, 1, maxNumber + 1, rand));
                    }
                    else
                    {
                        // use the constructor made for eurojackpot
                        rows.Add(new Row(numbers, 1, maxNumber + 1, rand, MAXNUMBEREUROJACKPOTSTARS, ROWLENGTHEUROJACKPOTSTARS));
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #region private variables
        const int 
            MAXNUMBERLOTTO = 40, 
            MAXNUMBERVIKINGLOTTO = 48, 
            MAXNUMBEREUROJACKPOT = 50,
            MAXNUMBEREUROJACKPOTSTARS = 10,
            ROWLENGTHLOTTO = 7,
            ROWLENGTHVIKINGLOTTO = 6,
            ROWLENGTHEUROJACKPOT = 5,
            ROWLENGTHEUROJACKPOTSTARS = 2;
        List<Row> rows;
        #endregion
    }
}
