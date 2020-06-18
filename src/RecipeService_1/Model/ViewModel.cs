using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeService_1.Model
{
    public class ViewModel : BaseClass
    {
        public static string ConnectionString = $"Data Source=\"{Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DB", "reciep.db")}\";Version=3;FailIfMissing=True;";

        public ObservableCollection<Reciep> Recieps { get; } = new ObservableCollection<Reciep>();
    }
}
