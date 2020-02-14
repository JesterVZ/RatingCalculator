<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RatingCalculator.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="style.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto+Condensed&display=swap" rel="stylesheet" />
</head>
<body class="preload">
    <div class="header">
        <h1>Калькулятор рейтинга</h1>
    </div>
    <form id="GetDataForm" runat="server">
        <div>
            <div class="GetRating">
                <label>Рейтинг игрока 1</label>
                <input type="text" value="" id="i1" runat="server"/>
            </div>
            <div class="GetRating">
                <label>Рейтинг игрока 2</label>
                <input type="text" value="" id="i2" runat="server"/>
            </div>
            <div class="GetRating">
                <label>Коэффициент K</label>
                <input type="text" value="" id="i3" runat="server"/>
            </div>
            <div class="GetRating">
                <label>Результат</label>
                <select id="ChooseResult" runat="server">
                    <option value="1">Выиграл первый</option>
                    <option value="0">Ничья</option>
                    <option value="-1">Выиграл второй</option>
                </select>
            </div>
            <div class="result"></div>
            <div>
                    <button type="submit">Расчет</button>
            </div>
            <div id="resultDiv" runat="server"></div>

        </div>
            <a href="Task3.html">Верстка</a>
    </form>
</body>
</html>
