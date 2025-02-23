namespace MyFirstConsoleApp
{
    
    public class SomeClasses1
    {
    
    }

    public class Dog1
    {
        public void Bark()
        {
        
        }
    }

    /// <summary>
    /// 같은 네이스페이스 안에 같은 클래스명을 사용시
    /// partial 사용
    /// 그런데 이렇게 사용할 필요하 있나?
    /// </summary>
    public partial class Cat
    {
        public void Purr()
        {
        
        }
    }
}
