using System;
using System.IO;

namespace WebApplication5.Services
{
    public class MyFileWatcher
    {
        /**
         * File 생성등 감시 시작
         */
        public void RunFileWatcher()
        {
            try
            {
                FileSystemWatcher watcher = new FileSystemWatcher();
                var watcherPath = @"D:\MyFolder";
                
                // 감시 폴더가 없으면 생성
                if (!Directory.Exists(watcherPath))
                {
                    Directory.CreateDirectory(watcherPath);
                    Console.WriteLine($"감시 폴더 생성됨: {watcherPath}");
                }
                
                watcher.Path = watcherPath;
                watcher.Filter = "*.*";
                watcher.IncludeSubdirectories = true;
                
                // // 감시할 변경 유형 설정
                // watcher.NotifyFilter = NotifyFilters.LastWrite
                //                        | NotifyFilters.FileName
                //                        | NotifyFilters.DirectoryName;

                // 이벤트 핸들러 등록
                watcher.Changed += OnFileChanged;
                watcher.Created += OnFileCreated;
                watcher.Deleted += OnFileDeleted;
                watcher.Renamed += OnFileRenamed;

                // 감시 시작
                watcher.EnableRaisingEvents = true;

                Console.WriteLine("파일 감시를 시작합니다. 종료하려면 'q'를 누르세요.");
                while (Console.Read() != 'q') ;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
            }
        }
        
        
        private static void OnFileChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine($"파일 변경 감지: {e.FullPath}");
            LogToFile($"변경: {e.FullPath}");
        }

        private static void OnFileCreated(object source, FileSystemEventArgs e)
        {
            Console.WriteLine($"파일 생성 감지: {e.FullPath}");
            LogToFile($"생성: {e.FullPath}");
        }

        private static void OnFileDeleted(object source, FileSystemEventArgs e)
        {
            Console.WriteLine($"파일 삭제 감지: {e.FullPath}");
            LogToFile($"삭제: {e.FullPath}");
        }

        private static void OnFileRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine($"파일 이름 변경 감지: {e.OldFullPath} -> {e.FullPath}");
            LogToFile($"이름변경: {e.OldFullPath} -> {e.FullPath}");
        }

        private static void LogToFile(string message)
        {
            string logPath = @"D:\FileWatcher.log";
            try
            {
                using (StreamWriter sw = File.AppendText(logPath))
                {
                    sw.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"로그 기록 중 오류 발생: {ex.Message}");
            }
        }
    }
}