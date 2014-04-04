﻿namespace WpfTestApplication
{
    #region using

    using System.Linq;
    using System.Windows;
    using System.Windows.Automation.Peers;
    using System.Windows.Controls.Ribbon;

    #endregion

    public class RibbonTabExt : RibbonTab
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new RibbonTabAutomationPeerExt(this);
        }

        // Класс наследуется от стандартного Peer для RibbonTab
        private class RibbonTabAutomationPeerExt : RibbonTabAutomationPeer
        {
            public RibbonTabAutomationPeerExt(RibbonTab owner)
                : base(owner)
            {
            }

            // Меняем только возврат точки клика
            protected override Point GetClickablePointCore()
            {
                // Получаем детей элемента
                var childs = GetChildrenCore();

                if (childs != null)
                {
                    // В детях ищем заголовок
                    var header =
                        childs.FirstOrDefault(peer => peer.GetAutomationControlType() == AutomationControlType.Header);

                    // Если заголовок нашелся (а теоретически он должен быть всегда), возвращаем его точку клика
                    if (header != null)
                    {
                        return header.GetClickablePoint();
                    }
                }

                // Если с заголовком что-то пошло не так, то...по дефолту
                return base.GetClickablePointCore();
            }
        }
    }
}