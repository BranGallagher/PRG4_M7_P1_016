using Microsoft.AspNetCore.Mvc;
using PRG4_M7_P1_016.Models;
using System.Data.SqlClient;

namespace PRG4_M7_P1_016.Data
{
    public class OurDbContext
    {
        private readonly string _connectionString;
        private readonly SqlConnection _connection;

        public OurDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _connection = new SqlConnection(_connectionString);
        }

        public List<Buku> GetAllData()
        {
            List<Buku> bukuList = new List<Buku>();
            try
            {
                string query = "select * from Buku";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Buku buku = new Buku
                    {
                        id = Convert.ToInt32(reader["id"]),
                        judul = reader["judul"].ToString(),
                        penulis = reader["penulis"].ToString(),
                        penerbit = reader["penerbit"].ToString(),
                        issn = reader["issn"].ToString(),
                        tahun = Convert.ToInt32(reader["tahun"]),
                        status = Convert.ToInt32(reader["status"])
                    };
                    bukuList.Add(buku);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
            return bukuList;
        }

        public Buku GetData(int id)
        {
            Buku buku = new Buku();
            try
            {
                string query = "select * from Buku where id = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    buku.id = Convert.ToInt32(reader["id"]);
                    buku.judul = reader["judul"].ToString();
                    buku.penulis = reader["penulis"].ToString();
                    buku.penerbit = reader["penerbit"].ToString();
                    buku.issn = reader["issn"].ToString();
                    buku.tahun = Convert.ToInt32(reader["tahun"]);
                    buku.status = Convert.ToInt32(reader["status"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
            return buku;
        }

        public void insertDataBuku(Buku bukumodel)
        {
            try
            {
                string query = "INSERT INTO Buku VALUES(@p1,@p2,@p3,@p4,@p5,1)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", bukumodel.judul);
                command.Parameters.AddWithValue("@p2", bukumodel.penulis);
                command.Parameters.AddWithValue("@p3", bukumodel.penerbit);
                command.Parameters.AddWithValue("@p4", bukumodel.issn);
                command.Parameters.AddWithValue("@p5", bukumodel.tahun);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void updateDataBuku(Buku bukumodel)
        {
            try
            {
                string query = "UPDATE Buku SET judul = @p2, penulis = @p3, penerbit = @p4, issn = @p5, tahun = @p6 WHERE id = @p1";
                Console.WriteLine(bukumodel.issn);
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", bukumodel.id);
                command.Parameters.AddWithValue("@p2", bukumodel.judul);
                command.Parameters.AddWithValue("@p3", bukumodel.penulis);
                command.Parameters.AddWithValue("@p4", bukumodel.penerbit);
                command.Parameters.AddWithValue("@p5", bukumodel.issn);
                command.Parameters.AddWithValue("@p6", bukumodel.tahun);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void deleteDataBuku(int id)
        {
            try
            {
                string query = "DELETE FROM Buku WHERE id = @p1";
                using SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //ANGGOTA---------------------------------------------------------
        public List<Anggota> getAllDataAnggota()
        {
            List<Anggota> Anggotalist = new List<Anggota>();
            try
            {
                string query = "SELECT * FROM Anggota";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Anggota anggota = new Anggota()
                    {
                        id = Convert.ToInt32(reader["id"].ToString()),
                        nama = reader["nama"].ToString(),
                        umur = Convert.ToInt32(reader["umur"].ToString()),
                        alamat = reader["alamat"].ToString(),
                        noHP = reader["noHP"].ToString(),
                    };
                    Anggotalist.Add(anggota);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Anggotalist;
        }
        public Anggota getDataAnggota(int id)
        {
            Anggota AgtModel = new Anggota();
            try
            {
                string query = "SELECT * FROM Anggota WHERE id = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id);

                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                AgtModel.id = Convert.ToInt32(reader["id"].ToString());
                AgtModel.nama = reader["nama"].ToString();
                AgtModel.umur = Convert.ToInt32(reader["umur"].ToString());
                AgtModel.alamat = reader["alamat"].ToString();
                AgtModel.noHP = reader["noHP"].ToString();
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return AgtModel;
        }
        public void insertDataAnggota(Anggota Agt)
        {
            try
            {
                string query = "INSERT INTO Anggota VALUES(@p1,@p2,@p3,@p4)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", Agt.nama);
                command.Parameters.AddWithValue("@p2", Agt.umur);
                command.Parameters.AddWithValue("@p3", Agt.alamat);
                command.Parameters.AddWithValue("@p4", Agt.noHP);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void updateDataAnggota(Anggota Agtmodel)
        {
            try
            {
                string query = "UPDATE Anggota SET nama = @p2" +
                    ", umur = @p3" +
                    ", alamat = @p4" +
                    ", noHP = @p5" +
                    " WHERE id = @p1";
                using SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", Agtmodel.id);
                command.Parameters.AddWithValue("@p2", Agtmodel.nama);
                command.Parameters.AddWithValue("@p3", Agtmodel.umur);
                command.Parameters.AddWithValue("@p4", Agtmodel.alamat);
                command.Parameters.AddWithValue("@p5", Agtmodel.noHP);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void deleteDataAnggota(int id)
        {
            try
            {
                string query = "DELETE FROM Anggota WHERE id = @p1";
                using SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
