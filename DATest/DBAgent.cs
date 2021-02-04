using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DATest
{
    class DBAgent
    {
        private string _con
        { set; get; }
        public DBAgent(string con)
        {
            _con = con;
        }

        public void Select()
        {
            SqlConnection cn = new SqlConnection(_con);
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP 10 Vehicles.Id, Brand, Model, AdditionalProperties, Defects FROM Vehicles, VehicleModels WHERE VehicleModels.Id = ModelId", _con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            da.Dispose();
            Console.WriteLine("-----------Top 10 select results");
            foreach (DataRow r in dt.Rows)
                Console.WriteLine("ID: " + r["Id"] + ", brand: " + r["Brand"] + ", model: " + r["Model"] + ", additional properties: " + r["AdditionalProperties"] + ", defects: " + r["Defects"] + ".");
        }

        public int Insert(string newBrand, string newModel)
        {
            SqlConnection cn = new SqlConnection(_con);
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand select = new SqlCommand("SELECT Id, Brand, Model from VehicleModels", cn);
            SqlCommand insert = new SqlCommand("INSERT INTO VehicleModels (Brand, Model) VALUES (@brand, @model);", cn);
            insert.Parameters.Add(new SqlParameter("@brand", SqlDbType.VarChar, 50, "Brand"));
            insert.Parameters.Add(new SqlParameter("@model", SqlDbType.VarChar, 50, "Model"));
            da.SelectCommand = select;
            da.InsertCommand = insert;
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow newRow = dt.NewRow();
            newRow["Brand"] = newBrand;
            newRow["Model"] = newModel;
            dt.Rows.Add(newRow);
            da.Update(dt);

            // retreave ID of the last inserted row
            da = new SqlDataAdapter("SELECT Id from VehicleModels WHERE Brand = '" + newBrand + "' AND Model = '" + newModel + "';", cn);
            dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            da.Dispose();
            return (int)dt.Rows[0]["Id"];
        }

        public void Update(int id, string brandChanged, string modelChanged)
        {
            SqlConnection cn = new SqlConnection(_con);
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM VehicleModels", cn);
            SqlCommand update = new SqlCommand();
            update.Connection = cn;
            update.CommandType = CommandType.Text;
            update.CommandText = "UPDATE VehicleModels SET Brand = @brand, Model = @model WHERE Id = @id;";
            update.Parameters.Add(new SqlParameter("@Brand", SqlDbType.VarChar, 50, "Brand"));
            update.Parameters.Add(new SqlParameter("@model", SqlDbType.VarChar, 50, "Model"));
            update.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 1000, "Id"));
            da.UpdateCommand = update;
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i;
            for (i = 0; i < dt.Rows.Count; i++)
            {
                if ((int)dt.Rows[i]["Id"] == id)
                {
                    break;
                }
            }
            dt.Rows[i]["Brand"] = brandChanged;
            dt.Rows[i]["Model"] = modelChanged;
            da.Update(dt);
            cn.Close();
            da.Dispose();
        }

        public void Delete(int id)
        {
            SqlConnection cn = new SqlConnection(_con);
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM VehicleModels", cn);
            SqlCommand delete = new SqlCommand();
            delete.Connection = cn;
            delete.CommandType = CommandType.Text;
            delete.CommandText = "DELETE FROM VehicleModels WHERE Id = @id";
            delete.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 1000, "Id"));
            da.DeleteCommand = delete;
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i;
            for (i = 0; i < dt.Rows.Count; i++)
            {
                if ((int)dt.Rows[i]["Id"] == id)
                {
                    break;
                }
            }
            dt.Rows[i].Delete();
            da.Update(dt);
            cn.Close();
            da.Dispose();
        }
    }
}