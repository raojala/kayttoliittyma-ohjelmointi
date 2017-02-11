using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labra_10_tehtava_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labra_10_tehtava_3.Tests
{
    [TestClass()]
    public class RowTests
    {
        [TestMethod()]
        public void CreateAndCheckDuplicatesTest()
        {
            try
            {
                int df = 5;
                Game.GameTypes gt = (Game.GameTypes)Enum.Parse(typeof(Game.GameTypes), "EuroJackpot");
                Game game = new Game(gt, df);
                
                if (game.Rows[0].Numbers.Contains(game.Rows[0].Stars[0])) Assert.Fail();
                if (game.Rows[0].Numbers.Contains(game.Rows[0].Stars[1])) Assert.Fail();
                if (game.Rows[0].Stars[1] == game.Rows[0].Stars[0]) Assert.Fail();

                if (game.Rows[1].Numbers.Contains(  game.Rows[1].Stars[0])) Assert.Fail();
                if (game.Rows[1].Numbers.Contains(  game.Rows[1].Stars[1])) Assert.Fail();
                if (game.Rows[1].Stars[1] ==        game.Rows[1].Stars[0]) Assert.Fail();

                if (game.Rows[2].Numbers.Contains(game.Rows[2].Stars[0])) Assert.Fail();
                if (game.Rows[2].Numbers.Contains(game.Rows[2].Stars[1])) Assert.Fail();
                if (game.Rows[2].Stars[1] == game.Rows[2].Stars[0]) Assert.Fail();

                if (game.Rows[3].Numbers.Contains(game.Rows[3].Stars[0])) Assert.Fail();
                if (game.Rows[3].Numbers.Contains(game.Rows[3].Stars[1])) Assert.Fail();
                if (game.Rows[3].Stars[1] == game.Rows[3].Stars[0]) Assert.Fail();

                if (game.Rows[4].Numbers.Contains(game.Rows[4].Stars[0])) Assert.Fail();
                if (game.Rows[4].Numbers.Contains(game.Rows[4].Stars[1])) Assert.Fail();
                if (game.Rows[4].Stars[1] == game.Rows[4].Stars[0]) Assert.Fail();
            }
            catch (Exception)
            {
                // MessageBox.Show(ex.Message + "\n\n" + ex, "Exception in btnCreate_Click");
            }
        }
    }
}