using System;
using System.Collections.Generic;

namespace RatingLibrary
{
    public class EloRating
    {
        private const double Divider = 400;
        private const double DefaultCoefficient = 20;

        private SortedList<double, double> _coefficientStructure = new SortedList<double, double>(new DescendingComparer<double>());

        /**
         * Конструктор с передачей параметров расчета коэффициента
         */
        public EloRating(SortedList<double, double> coefficientStructure)
        {
            if (coefficientStructure == null)
            {
                initDefaultCoefficientStructure();
                return;
            }
            foreach (var value in coefficientStructure)
            {
                _coefficientStructure.Add(value.Key, value.Value);
            }
        }
        /**
         * Конструктор без передачи параметров расчета коэффициента
         */
        public EloRating()
        {
            initDefaultCoefficientStructure();
        }

        private void initDefaultCoefficientStructure()
        {
            // Зададим параметры расчета коэффициента по-умолчанию

            _coefficientStructure = new SortedList<double, double>(new DescendingComparer<double>())
            {
                // 20 для игроков с рейтингом меньше, чем 2400
                {0, DefaultCoefficient}, 
                // 10 для сильнейших игроков (рейтинг 2400 и выше)
                {2400, 10}
            };
        }

        /**
         * Функция расчета рейтинга
         */
        public RatingStructure CalcRating(double player1Rating, double player2Rating, MatchResult matchResult)
        {
            var player1ExpectedValue = 1 / (1 + Math.Pow(10, (player2Rating - player1Rating / Divider)));
            var player2ExpectedValue = 1 / (1 + Math.Pow(10, (player1Rating - player2Rating / Divider)));

            var player1PointCount = 0.5;
            var player2PointCount = 0.5;
            switch (matchResult)
            {
                case MatchResult.FirstPlayerIsWinner:
                    player1PointCount = 1;
                    player2PointCount = 0;
                    break;
                case MatchResult.SecondPlayerIsWinner:
                    player1PointCount = 0;
                    player2PointCount = 1;
                    break;
            }

            return new RatingStructure
            {
                Player1Rating = player1Rating + GetCoefficient(player1Rating) * (player1PointCount - player1ExpectedValue),
                Player2Rating = player2Rating + GetCoefficient(player2Rating) * (player2PointCount - player2ExpectedValue)
            };
        }

        /**
         * Функция получения коэффициента для расчета рейтинга
         */
        private double GetCoefficient(double rating)
        {
            // Структура коэффициентов отсортирована по убыванию, поэтому найдем первое значение ключа, меньше заданного рейтинга
            foreach (var value in _coefficientStructure)
            {
                if (value.Key <= rating)
                {
                    return value.Value;
                }
            }
            // Не нашли из структуры расчета коэффициентов - вернем значение по-умолчанию
            return DefaultCoefficient;
        }

    }

    // Структура, возвращаемая функцией расчета рейтинга
    public struct RatingStructure
    {
        public double Player1Rating;
        public double Player2Rating;
    }

    // Перечисление, описывающее результат матча
    public enum MatchResult
    {
        FirstPlayerIsWinner,
        SecondPlayerIsWinner,
        Draw
    }

    // Компаратор для сортировки в структуре коэффициентов от большего к меньшему
    internal class DescendingComparer<TKey> : IComparer<double>
    {
        public int Compare(double x, double y)
        {
            return y.CompareTo(x);
        }
    }
}
