﻿namespace Winium.Cruciatus.Core
{
    #region using

    using System.Threading;
    using System.Windows;

    using WindowsInput;

    #endregion

    /// <summary>
    /// Симулятор мыши. Обёртка над WindowsInput.MouseSimulator .
    /// </summary>
    public class MouseSimulatorExt
    {
        #region Fields

        private readonly IMouseSimulator mouseSimulator;

        #endregion

        #region Constructors and Destructors

        internal MouseSimulatorExt(IMouseSimulator mouseSimulator)
        {
            this.mouseSimulator = mouseSimulator;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Эмулирует клик в заданные координаты.
        /// </summary>
        /// <param name="button">
        /// Целевая кнопка.
        /// </param>
        /// <param name="x">
        /// Координата точки по оси X.
        /// </param>
        /// <param name="y">
        /// Координата точки по оси Y.
        /// </param>
        public void Click(MouseButton button, double x, double y)
        {
            this.SetCursorPos(x, y);
            switch (button)
            {
                case MouseButton.Left:
                    this.LeftButtonClick();
                    break;
                case MouseButton.Right:
                    this.RightButtonClick();
                    break;
            }
        }

        /// <summary>
        /// Эмулирует двойной клик в заданные точку.
        /// </summary>
        /// <param name="button">
        /// Целевая кнопка.
        /// </param>
        /// <param name="x">
        /// Координата точки по оси X.
        /// </param>
        /// <param name="y">
        /// Координата точки по оси Y.
        /// </param>
        public void DoubleClick(MouseButton button, double x, double y)
        {
            this.SetCursorPos(x, y);
            switch (button)
            {
                case MouseButton.Left:
                    this.LeftButtonDoubleClick();
                    break;
                case MouseButton.Right:
                    this.RightButtonDoubleClick();
                    break;
            }
        }

        /// <summary>
        /// Эмулярует клик левой кнопки мыши в текущем положении курсора.
        /// </summary>
        public void LeftButtonClick()
        {
            this.mouseSimulator.LeftButtonClick();
            Thread.Sleep(250);
        }

        /// <summary>
        /// Эмулярует двойной клик левой кнопки мыши в текущем положении курсора.
        /// </summary>
        public void LeftButtonDoubleClick()
        {
            this.mouseSimulator.LeftButtonDoubleClick();
            Thread.Sleep(250);
        }

        /// <summary>
        /// Эмулярует клик правой кнопки мыши в текущем положении курсора.
        /// </summary>
        public void RightButtonClick()
        {
            this.mouseSimulator.RightButtonClick();
            Thread.Sleep(250);
        }

        /// <summary>
        /// Эмулярует двойной клик правой кнопки мыши в текущем положении курсора.
        /// </summary>
        public void RightButtonDoubleClick()
        {
            this.mouseSimulator.RightButtonDoubleClick();
            Thread.Sleep(250);
        }

        /// <summary>
        /// Устанавливает курсор в заданную точку.
        /// </summary>
        /// <param name="x">
        /// Координата точки по оси X.
        /// </param>
        /// <param name="y">
        /// Координата точки по оси Y.
        /// </param>
        public void SetCursorPos(double x, double y)
        {
            var virtualScreenPoint = ScreenCoordinatesHelper.ScreenPointToVirtualScreenPoint(new Point(x, y));
            this.mouseSimulator.MoveMouseToPositionOnVirtualDesktop(virtualScreenPoint.X, virtualScreenPoint.Y);
            Thread.Sleep(250);
        }

        /// <summary>
        /// Эмулирует вертикальную прокрутку.
        /// </summary>
        /// <param name="amountOfClicks">
        /// Количество кручений в кликах. Положительное значение - вверх, отрицательное - вниз.
        /// </param>
        public void VerticalScroll(int amountOfClicks)
        {
            this.mouseSimulator.VerticalScroll(amountOfClicks);
            Thread.Sleep(250);
        }

        #endregion
    }
}
