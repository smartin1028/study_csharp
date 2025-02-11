using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApplication5.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Linq;
using Dapper;


namespace WebApplication5.Controllers
{
    public class BoardController : ApiController
    {
        public List<Board> Get()
        {
            var boards = new List<Board>();
            
            var connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=11521))(CONNECT_DATA=(SERVICE_NAME=XE)));User Id=greenpen;Password=abca156324;";
            try
            {
                using (var connection = new OracleConnection(connectionString))
                {
                                 
                    connection.Open();
                    Console.WriteLine("데이터베이스 연결 성공!");
                    // using Dapper; 사용시
                    boards = connection.Query<Board>("SELECT BOARD_ID, TITLE, CONTENT, WRITER, REG_DATE, VIEW_COUNT, REPLY_COUNT FROM GREENPEN.TB_board").ToList();
                    // using (var command = connection.CreateCommand())
                    // {
                    //     command.CommandText = "SELECT * FROM your_table";
                    //     using (var reader = command.ExecuteReader())
                    //     {
                    //         while (reader.Read())
                    //         {
                    //             // 데이터 처리
                    //             var column1 = reader["column_name"].ToString();
                    //         }
                    //     }
                    // }
                    // 여기에 쿼리 실행 코드 작성
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            
            return boards;
        }
    }

}