using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeService_1.Model
{
    public class Reciep : BaseClass
    {
        public Reciep()
        {
            SaveCommand = new RelayCommand((param) => Save());
        }

        private long? _ID;
        public long? ID
        {
            get { return _ID; }
            set { _ID = value; RaisePropertyChanged(nameof(ID)); }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; RaisePropertyChanged(nameof(Description)); }
        }


       public RelayCommand SaveCommand { get; }
        public void Save()
        {
            using (var conn = new SQLiteConnection(ViewModel.ConnectionString, true))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                cmd.CommandText = "REPLACE INTO recieps(ID, Description) VALUES(@ID, @Description);";

                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Description", Description);

                cmd.ExecuteNonQuery();

                ID = conn.LastInsertRowId;

                conn.Close();
            } 
            
        }
    }
}
