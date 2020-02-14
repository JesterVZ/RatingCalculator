using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RatingCalculator
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var CoefficientList = new SortedList<double, double>();

            if (IsPostBack){
                double Rating1FromInput = Math.Round(Convert.ToDouble(i1.Value));
                double Rating2FromInput = Math.Round(Convert.ToDouble(i2.Value));
                int CoefficientFromInput = Convert.ToInt32(i3.Value);
                int ResultFromSelect = Convert.ToInt32(ChooseResult.Value);
                CoefficientList.Add(0, Convert.ToDouble(CoefficientFromInput));
                RatingLibrary.MatchResult MathResultVar = RatingLibrary.MatchResult.Draw;

                switch (ResultFromSelect)
                {
                    case 0:
                        MathResultVar = RatingLibrary.MatchResult.Draw;
                        break;
                    case 1:
                        MathResultVar = RatingLibrary.MatchResult.FirstPlayerIsWinner;
                        break;
                    case -1:
                        MathResultVar = RatingLibrary.MatchResult.SecondPlayerIsWinner;
                        break;
                }

                var ratingLibrary = new RatingLibrary.EloRating(CoefficientList);
                var result = ratingLibrary.CalcRating(Rating1FromInput, Rating2FromInput, MathResultVar);
                resultDiv.InnerHtml += "Рейтинг 1 :" + result.Player1Rating.ToString() + " Рейтинг 2 :" + result.Player2Rating.ToString() + "<br>";
                i1.Value = result.Player1Rating.ToString();
                i2.Value = result.Player2Rating.ToString();

            }

        }

    }
}