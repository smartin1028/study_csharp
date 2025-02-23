using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace CodeSnippetManager
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<CodeSnippet> snippets;

        public MainWindow()
        {
            InitializeComponent();
            snippets = new ObservableCollection<CodeSnippet>();
            snippetList.ItemsSource = snippets;
            snippetList.DisplayMemberPath = "Title";
            snippetList.SelectionChanged += SnippetList_SelectionChanged;

            // 텍스트 변경 이벤트 핸들러 추가
            snippetEditor.TextChanged += SnippetEditor_TextChanged;

        }

        /// <summary>
        /// 텍스트 입력이 변경되면 자동으로 저장되도록 추가
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SnippetEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            var selectedSnippet = snippetList.SelectedItem as CodeSnippet;
            if (selectedSnippet != null)
            {
                selectedSnippet.Code = snippetEditor.Text;
                // 상태 표시줄이나 타이틀바에 "저장됨" 표시를 할 수 있습니다
                this.Title = "코드 스니펫 매니저 - 저장됨";
            }
        }

        private void AddNewSnippet_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new InputDialog("새 스니펫", "스니펫 제목을 입력하세요:");
            if (dialog.ShowDialog() == true)
            {
                var newSnippet = new CodeSnippet
                {
                    Title = dialog.ResponseText,
                    Code = string.Empty
                };
                snippets.Add(newSnippet);
                snippetList.SelectedItem = newSnippet;
            }
        }

        private void SaveSnippet_Click(object sender, RoutedEventArgs e)
        {
            var selectedSnippet = snippetList.SelectedItem as CodeSnippet;
            if (selectedSnippet != null)
            {
                selectedSnippet.Code = snippetEditor.Text;
                MessageBox.Show("스니펫이 저장되었습니다.");
            }
        }

        private void SnippetList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedSnippet = snippetList.SelectedItem as CodeSnippet;
            if (selectedSnippet != null)
            {
                snippetEditor.Text = selectedSnippet.Code;
            }
            else
            {
                snippetEditor.Text = string.Empty;
            }
        }
        // MainWindow.xaml.cs에 추가
        private void SaveToFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Snippet files (*.snp)|*.snp",
                    DefaultExt = ".snp"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    var snippetsJson = System.Text.Json.JsonSerializer.Serialize(snippets);
                    var encrypted = EncryptionUtil.Encrypt(snippetsJson);
                    Console.WriteLine(encrypted);
                    File.WriteAllText(saveFileDialog.FileName, encrypted);
                    MessageBox.Show("스니펫이 암호화되어 파일로 저장되었습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"저장 중 오류 발생: {ex.Message}");
            }
        }

        private void LoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog
                {
                    Filter = "Snippet files (*.snp)|*.snp"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    var encrypted = File.ReadAllText(openFileDialog.FileName);
                    var decrypted = EncryptionUtil.Decrypt(encrypted);
                    var loadedSnippets = System.Text.Json.JsonSerializer.Deserialize<ObservableCollection<CodeSnippet>>(decrypted);

                    snippets.Clear();
                    foreach (var snippet in loadedSnippets)
                    {
                        snippets.Add(snippet);
                    }
                    MessageBox.Show("스니펫을 성공적으로 불러왔습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"파일 로드 중 오류 발생: {ex.Message}");
            }
        }
    }

    public class CodeSnippet
    {
        public string Title { get; set; }
        public string Code { get; set; }
    }
}