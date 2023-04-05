using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercisepabd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program pr = new Program();
            while (true)
            {
                try
                {
                    Console.WriteLine("Koneksi ke Database\n");
                    Console.WriteLine("Masukkan User ID :");
                    string user = Console.ReadLine();
                    Console.WriteLine("Masukkan Password");
                    string pass = Console.ReadLine();
                    Console.WriteLine("Masukkan database tujuan");
                    string db = Console.ReadLine();
                    Console.Write("\nKetik K untuk Terhubung ke Database: ");
                    char chr = Convert.ToChar(Console.ReadLine());
                    switch (chr)
                    {
                        case 'K':
                            {
                                SqlConnection conn = null;
                                string strKoneksi = "Data source = MAD\\MADDOG12; " +
                                "initial catalog = {0}; " + "User ID {1}; password = {2}";
                                conn = new SqlConnection(string.Format(strKoneksi, db, user, pass));
                                conn.Open();
                                Console.Clear();
                                while (true)
                                {
                                    try
                                    {
                                        Console.WriteLine("\nMenu");
                                        Console.WriteLine("1. Melihat Seluruh Data");
                                        Console.WriteLine("2. Tambah Data");
                                        Console.WriteLine("3. Keluar");
                                        Console.Write("\nEnter your choice (1-3):");
                                        char ch = Convert.ToChar(Console.ReadLine());
                                        switch (ch)
                                        {
                                            case '1':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("DATA SISWA BARU");
                                                    pr.baca(conn);
                                                    conn.Close();
                                                }
                                                break;
                                            case '2':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Masukkan NIS :");
                                                    string NIS = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Nama : ");
                                                    string Namasiswa = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Jenis Kelamin (L/P) : ");
                                                    string Jk = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Alamat : ");
                                                    string Almt = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Asal Sekolah : ");
                                                    string As = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Kode Kelas : ");
                                                    string Kk = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Kode Jurusan : ");
                                                    string Kj = Console.ReadLine();
                                                    try
                                                    {
                                                        pr.insert(NIS, Namasiswa, Jk, Almt, As, Kk, Kj);
                                                        conn.Close();
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("\nAnda tidak memiliki " + "akses untuk menambah data");
                                                    }
                                                }
                                                break;
                                            case '3':
                                                conn.Close();
                                                return;
                                            default:
                                                {

                                                    Console.Clear();
                                                    Console.WriteLine("\nInvalid Option");
                                                }
                                                break;
                                        }
                                    }
                                    catch
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Tidak Dapat Mengakses Database Menggunakan User Tersebut\n");
                                        Console.ResetColor();
                                    }
                                }
                            }
                    }


                }

            }
        }

        private void insert(string nIS, string namasiswa, string jk, string almt, string @as, string kk, string kj)
        {
            throw new NotImplementedException();
        }

        private void baca(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("Select * From HRD.Siswa", conn);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; i++)
                {
                    Console.WriteLine(r.GetValue(i));
                }
                Console.WriteLine();
            }
        }
        public void insert(string NIS, string Namasiswa, string Jk, string Almt, string Kk, string Kj, SqlConnection con)
        {
            string str = "";
            str = "insert into HRD.Siswa (NIS, Nama_siswa, Jenis_Kelamin, Alamat, Asal_Sekolah, Kode_Kelas, Kode_Jurusan)"
                + "values(@nis,@namasiswa,@Jk,@alamat,@As,@Kk,@Kj)";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("nis", NIS));
            cmd.Parameters.Add(new SqlParameter("namasiswa", Namasiswa));
            cmd.Parameters.Add(new SqlParameter("Jk", Jk));
            cmd.Parameters.Add(new SqlParameter("alamat", Almt));
            cmd.Parameters.Add(new SqlParameter("Kk", Kk));
            cmd.Parameters.Add(new SqlParameter("Kj", Kj));
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Berhasil Di Tambahkan");
        }
    }
}
