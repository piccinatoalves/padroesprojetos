 class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sem proxy\n---------\n");
 
 
            Usuario usuario = new Usuario();
 
 
            Console.WriteLine(usuario.Consultar());
            Console.WriteLine();
 
 
            Console.WriteLine();
            Console.WriteLine();
 
 
            Console.WriteLine("Usando proxy para controlar acesso");
            Console.WriteLine("----------------------------------");
 
 
            Console.WriteLine();
 
 
            ProxyUsuario proxy;
            proxy = new ProxyUsuario();
 
 
            //tentando consultar sem autenticar
            Console.WriteLine(proxy.Consultar());
            Console.WriteLine();
 
 
            //autenticando com senha incorreta
            Console.WriteLine(proxy.Autenticar("senhaErrada"));
            Console.WriteLine(proxy.Consultar());
            Console.WriteLine();
 
 
            //agora, sim...
            Console.WriteLine(proxy.Autenticar("53NH4"));
            Console.WriteLine(proxy.Consultar());
            Console.WriteLine();
 
 
            Console.ReadKey();
        }
    }
 
 
    //ISubject
    public interface IUsuario
    {
        //Request()
        String Consultar();
    }
 
 
    //Subject
    public class Usuario
    {
        public Usuario()
        {
            Console.WriteLine("criei");
        }
 
 
        //Request()
        public String Consultar()
        {
            return String.Format("consultei");
        }
    }
 
 
    //Proxy
    public class ProxyUsuario : IUsuario
    {
        //ISubject
        Usuario u;
 
 
        String senha = "53NH4";
 
 
        //Request
        public String Consultar()
        {
            String retorno = "autentique-se";
 
 
            if (this.u != null)
                retorno = u.Consultar();
 
 
            return retorno;
        }
 
 
        public String Autenticar(String s)
        {
            String retorno = "sem acesso";
 
 
            if (s == this.senha)
            {
                this.u = new Usuario();
                retorno = "usuário autenticado";
            }
 
            return retorno;
        }
    }
}