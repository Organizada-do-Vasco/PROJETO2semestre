﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio
{
    class DAOConexao
    {
         public  static MySqlConnection con;

       public static Boolean getConexao(String local, String banco, String user, String senha)
        {

            Boolean retorno = false;
            try
            {
                con = new MySqlConnection("server=" + local + ";User ID=" + user + ";" + "database=" + banco + "; password=" + senha + "; SslMode = none");
                //  con.Open();
                retorno = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return retorno;

          }

        internal static bool login(string text1, string text2)
        {
            throw new NotImplementedException();
        }

        public static Boolean CadLogin(string usuario,string senha,int tipo)
        {
            bool cad = false;
            try
            {
                con.Open();
                MySqlCommand insere = new MySqlCommand("insert into Estudio_Login (usuario,senha,tipo)" + "values ('" + usuario + "','" + senha + "'," + tipo+")", con);
                insere.ExecuteNonQuery();
                cad = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return cad;
        }

        public static int Login(string usuario, string senha)
        {

            int tipo = 0;

            try
            {
                con.Open(); 
                MySqlCommand nome = new MySqlCommand("SELECT * FROM Estudio_Login WHERE usuario='"+usuario+"' and senha ='"+senha+"'", con);
                MySqlDataReader resultado = nome.ExecuteReader();

                if (resultado.Read())
                {
                    tipo = Convert.ToInt32(resultado["tipo"].ToString());
                }
            
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
            }

            return tipo;

        }
    }


}
