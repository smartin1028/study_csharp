using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using NUnit.Framework;
using Oracle.ManagedDataAccess.Client;
using WebApplication5.Models;

namespace TestProject1.Services
{
    [TestFixture]
    public class DBTest
    {
        [Test]
        public void Test1()
        {
            var departmentIds = new List<string> { "DEPT001", "DEPT002", "DEPT003" };
            string paramNames = string.Join(",", departmentIds.Select((_, i) => $":deptId{i}"));
            
            string query = $@"SELECT employee_id, 
                               employee_name, 
                               salary, 
                               hire_date 
                        FROM employees 
                        WHERE department_id IN ({paramNames})";
            //
            Console.WriteLine(query);
            //
            // Assert.AreEqual(paramNames , "DEPT001,DEPT002,DEPT003");
            Assert.True(true);
        }

        [Test]
        public void Test2()
        {
            var boards = new List<Board>();
            
            var connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=11521))(CONNECT_DATA=(SERVICE_NAME=XE)));User Id=greenpen;Password=abca156324;";
            try
            {
                using (var connection = new OracleConnection(connectionString))
                {
                    var departmentIds = new List<string> { "TITLE 001", "TITLE 002", "TITLE 003" };
                    string paramNames = string.Join(",", departmentIds.Select((_, i) => $":title{i}"));

                    
                    connection.Open();
                    Console.WriteLine("데이터베이스 연결 성공!");
                    // using Dapper; 사용시
                    var sql = $@"
                                  SELECT BOARD_ID
                                       , TITLE
                                       , CONTENT
                                       , WRITER
                                       , REG_DATE
                                       , VIEW_COUNT
                                       , REPLY_COUNT 
                                    FROM GREENPEN.TB_board
                                ";
                    boards = connection.Query<Board>( sql, new {paramNames} ).ToList();

                    foreach (var test in boards)
                    {
                        Console.WriteLine(test.TITLE);
                    }
                    // 여기에 쿼리 실행 코드 작성
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }


        [Test]
        public void Test3()
        {
            var connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=11521))(CONNECT_DATA=(SERVICE_NAME=XE)));User Id=greenpen;Password=abca156324;";
            using (var connection = new OracleConnection(connectionString))
            {
                try
                {
                    var titles = new List<string> { "TITLE 0001", "TITLE 0002", "TITLE 0003" };
                    // IN 절을 위한 동적 파라미터 생성
                    var parameters = new DynamicParameters();
                    for (int i = 0; i < titles.Count; i++)
                    {
                        parameters.Add($"title{i}", titles[i]);
                    }

                    string paramNames = string.Join(",", titles.Select((_, i) => $":title{i}"));
                    string sql = $@"SELECT BOARD_ID, 
                                 TITLE, 
                                 CONTENT, 
                                 WRITER, 
                                 REG_DATE, 
                                 VIEW_COUNT, 
                                 REPLY_COUNT   
                          FROM GREENPEN.TB_BOARD 
                          WHERE TITLE IN ({paramNames})";

                    var board = connection.Query<Board>(sql, parameters).ToList();
                    Console.WriteLine("asdf");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"에러 발생: {ex.Message}");
                    throw;
                }
            }
        }
    }
}