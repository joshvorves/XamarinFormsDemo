using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MyPortableTest
{
    class TimeModel
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public TimeModel()
        {
            Time = DateTime.Now.ToString("T");
            Date = DateTime.Now.ToString("D");
        }
    }
    public class MyList : ContentPage
    {
        private readonly ObservableCollection<TimeModel> _items = new ObservableCollection<TimeModel>();

        public MyList()
        {
            var list = new ListView { ItemsSource = _items };

            var button = new Button { Text = "Click me" };

            button.Clicked += (sender, e) => _items.Add(new TimeModel());

            var stack = new StackLayout();

            stack.Children.Add(list);
            stack.Children.Add(button);

            var cell = new DataTemplate(typeof(TextCell));

            cell.SetBinding(TextCell.TextProperty, "Date");
            cell.SetBinding(TextCell.DetailProperty, "Time");

            list.ItemTemplate = cell;


            list.ItemTapped += (sender, e) =>
            {
                if (list.SelectedItem == null) return;

                var page = new ContentPage();
                var timeModel = list.SelectedItem as TimeModel;

                var label = new Label { Text = timeModel.Date + timeModel.Time };

                page.Content = label;

                Navigation.PushAsync(page);

                list.SelectedItem = null;
            };

            Content = stack;
        }
    }
}
