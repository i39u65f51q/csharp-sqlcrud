using MySql.Data.MySqlClient;
    public class SqlMethods
    {   
        static string connectedString = "server=127.0.0.1; port=3306; user=root; password=@eric0129; database=sqlTest; charset=utf8;";
        public static void Read()
        {
            MySqlConnection con = new MySqlConnection(connectedString);

            con.Open();
            Console.WriteLine("Connect SQL Successfully");
            string query = "SELECT name FROM people WHERE id = 1;";

            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader reader = cmd.ExecuteReader(); 

            while(reader.Read()){
                System.Console.WriteLine(reader[0].ToString());
            }
            
            Console.WriteLine("Disconnect SQL");
            con.Close();
        }
        public static void Insert(string name, int age){
            using(MySqlConnection sql = new MySqlConnection(connectedString)){
                string query ="INSERT INTO people (name, age)VALUES ( @name, @age);";  
                
                using(MySqlCommand cmd = new MySqlCommand(query, sql)){
                    cmd.Parameters.AddWithValue("@name", name); 
                    cmd.Parameters.AddWithValue("@age", age); 

                    sql.Open(); 
                    int index = cmd.ExecuteNonQuery();
                    Console.WriteLine(index < 1 ? "INSERT ERROR" : "INSERT SUCCESSFULLY");
                }
            } 
        }
        public static void Update(int id, string name, int age){
            using(MySqlConnection sql = new MySqlConnection(connectedString)){
                string query = "UPDATE people SET name = @name, age = @age WHERE id= @id;";

                using(MySqlCommand cmd = new MySqlCommand(query, sql)){
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@age", age);

                    sql.Open(); 
                    int index = cmd.ExecuteNonQuery();

                    Console.WriteLine(index < 1 ? "UPDATE ERROR" : "UPDATE SUCCESSFULLY");
                }
            }

        }
        public static void Delete(int id){
            MySqlConnection sql = new MySqlConnection(connectedString); 
            string query = "DELETE FROM people WHERE id = @id;";
            MySqlCommand cmd = new MySqlCommand(query, sql); 
            cmd.Parameters.AddWithValue("@id", id);

            sql.Open(); 
            int index = cmd.ExecuteNonQuery();
            Console.WriteLine(index < 1 ? "DELETE ERROR" : "DELETE SUCCESSFULLY");
            sql.Close();
        }
    }