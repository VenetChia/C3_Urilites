using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyLibrary
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    [ContentProperty("Content")]
    public partial class TabSwircher : UserControl
    {
        public TabSwircher()
        {
            InitializeComponent();
            btPrev.Click += btPrev_Click;
            btNext.Click += btNext_Click;
        }


        public static readonly DependencyProperty prevTextProperty = DependencyProperty.Register("PrevText", typeof(string), typeof(TabSwircher), new PropertyMetadata("Prev"));
        public static readonly DependencyProperty nextTextProperty = DependencyProperty.Register("NextText", typeof(string), typeof(TabSwircher), new PropertyMetadata("Next"));

        public static readonly RoutedEvent btPrevClichEvent = EventManager.RegisterRoutedEvent("btPreviousClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TabSwircher));
        public static readonly RoutedEvent btNextClichEvent = EventManager.RegisterRoutedEvent("btNextEClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TabSwircher));

        //public event RoutedEventHandler PrevClick;
        public event RoutedEventHandler NextClick;
        public string PrevText
        {
            get
            {
                return (string)GetValue(prevTextProperty);
            }
            set
            {
                SetValue(prevTextProperty, value);
            }
        }
        public string NextText
        {
            get
            {
                return (string)GetValue(nextTextProperty);
            }
            set
            {
                SetValue(nextTextProperty, value);
            }
        }

        private void btPrev_Click(object sender, RoutedEventArgs e)
        {
            //if (PrevClick != null)
            //    PrevClick.Invoke(sender, e);
            e.Handled = true;
            RoutedEventArgs args = new RoutedEventArgs(btPrevClichEvent);
            RaiseEvent(args);
        }

        //два вида записи условия

        private void btNext_Click(object sender, RoutedEventArgs e)
        {
            //NextClick?.Invoke(sender, e);
            e.Handled = true;
            RoutedEventArgs args = new RoutedEventArgs(btNextClichEvent);
            RaiseEvent(args);
        }

        public event RoutedEventHandler btPreviousClick
        {
            add { AddHandler(btPrevClichEvent, value); }
            remove { AddHandler(btPrevClichEvent, value); }
        }

        public event RoutedEventHandler btNextEClick
        {
            add { AddHandler(btNextClichEvent, value); }
            remove { AddHandler(btNextClichEvent, value); }
        }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            if (oldContent != null)
                throw new InvalidOperationException("Нельзя менять Content");
        }
    }
}