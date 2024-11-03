using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

class Program
{
    static void Main(string[] args)
    {
        // Ruta al chromedriver.exe en tu escritorio (ajusta la ruta según sea necesario)
        string chromeDriverPath = @"C:\Users\wagne\OneDrive\Escritorio";

        // Inicializa el ChromeDriver con la ruta especificada
        IWebDriver driver = new ChromeDriver(chromeDriverPath);

        try
        {
            // Navega a la página de creación de películas
            driver.Navigate().GoToUrl("http://localhost:5052/Create");

            // Rellena el formulario por ID
            driver.FindElement(By.Id("Pelicula_Titulo")).SendKeys("Toy Story 4");
            driver.FindElement(By.Id("Pelicula_Director")).SendKeys("Josh Cooley");
            driver.FindElement(By.Id("Pelicula_Descripcion")).SendKeys("Woody, Buzz Lightyear y el resto de los juguetes viven felices con su nueva dueña Bonnie, hasta que un nuevo juguete, Forky, se une al grupo y comienzan una nueva aventura.");
            driver.FindElement(By.CssSelector("input[type='radio'][value='true']")).Click(); // Estreno
            driver.FindElement(By.Id("Pelicula_Genero")).SendKeys("Animación");
            driver.FindElement(By.Id("Pelicula_EsAnimada")).Click(); // Animada
            driver.FindElement(By.Id("Pelicula_FechaEstreno")).SendKeys("2019-06-21");
            driver.FindElement(By.Id("Pelicula_UrlVideo")).SendKeys("https://www.youtube.com/watch?v=wmiIUN-7qhE");

            // Envía el formulario
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();

            // Verifica que la película fue agregada
            Console.WriteLine("Película agregada con éxito.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error: {ex.Message}");
        }
        finally
        {
            // Cierra el navegador
            driver.Quit();
        }
    }
}
