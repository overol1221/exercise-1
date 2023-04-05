using System;
using System.Collections.Generic;
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
                                                }
                                        }
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
            throw new NotImplementedException();
        }
    }
}
