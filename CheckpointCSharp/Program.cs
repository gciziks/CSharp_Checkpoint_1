class Produto
{

    // Variáveis + Getters e Setters
    public string Nome { get; set; }
    public double Preco { get; set; }
    public int Quantidade { get; set; }

    // Construtor da Classe
    public Produto(string nome, double preco, int quantidade)
    {
        Nome = nome;
        Preco = preco;
        Quantidade = quantidade;
    }

    // Representação em texto
    public override string ToString()
    {
        return $"{Nome} - R${Preco:F2} - {Quantidade} Disponíveis";
    }
}

class Pedido
{
    // Lista de itens no pedido -> cada item é uma tupla que contém um objeto Produto e a qtd
    public List<(Produto Produto, int Quantidade)> Itens { get; } = new();

    // Adiciona um produto ao pedido caso a quantidade desejada esteja disponivel
    public void AdicionarProduto(Produto produto, int quantidade)
    {
        if (produto.Quantidade >= quantidade)
        {
            // Caso tenha reduz a quantidade no estoque
            produto.Quantidade -= quantidade; 
            Itens.Add((produto, quantidade));
            Console.WriteLine($"{quantidade} {produto.Nome}(s) adicionado(s)!");
        }
        else
        {
            Console.WriteLine("Quantidade insuficiente");
        }
    }

    // Remove um item do pedido baseado na linha
    public void RemoverPorLinha(int linha)
    {
        if (linha > 0 && linha <= Itens.Count) // Verifica se a linha existe
        {
            var itemRemover = Itens[linha - 1];
            itemRemover.Produto.Quantidade += itemRemover.Quantidade; //Readiciona o item no estoque
            Itens.RemoveAt(linha - 1);
            Console.WriteLine($"Removido: {itemRemover.Produto.Nome} - Quantidade: {itemRemover.Quantidade}");
        }
        else
        {
            Console.WriteLine("Linha inválida!");
        }
    }

    // Exibe no console um resumo do pedido até o momento
    public void VisualizarPedido()
    {
        if (Itens.Count == 0)
        {
            Console.WriteLine("Pedido está vazio!");
        }
        else
        {
            Console.WriteLine("Resumo do Pedido:");
            for (int i = 0; i < Itens.Count; i++)
            {
                var item = Itens[i];
                Console.WriteLine($"{i + 1}. {item.Produto.Nome} - Quantidade: {item.Quantidade} - Total: R${item.Produto.Preco * item.Quantidade:F2}");
            }
        }
    }

    // Calcula o valor bruto do pedido no final
    public double CalcularValorBruto()
    {
        return Itens.Sum(item => item.Produto.Preco * item.Quantidade);
    }

    // Calcula a quantidade total de itens no pedido para verificar se haverá frete grátis ou não
    public int CalcularQuantidadeTotal()
    {
        return Itens.Sum(item => item.Quantidade);
    }

    // Exibe um resumo final do pedido com descontos e frete grátis (se aplicável)
    public void ExibirResumoFinal()
    {
        double valorBruto = CalcularValorBruto();
        int quantidadeTotal = CalcularQuantidadeTotal();
        double desconto = 0;
        bool freteGratis = false;

        if (valorBruto > 100) // Desconto de 10% caso o total seja acima de 100 reais
        {
            desconto = valorBruto * 0.10;
        }
        else if (quantidadeTotal > 5) // Frete grátis para pedidos com + de 5 produtos (em quantidade)
        {
            freteGratis = true;
            Console.WriteLine("Você ganhou frete grátis!");
        }

        double valorFinal = valorBruto - desconto;

        // Mostra o resumo do pedido final
        Console.WriteLine("\n---- Resumo Final do Pedido ----");
        Console.WriteLine($"Total de Itens: {quantidadeTotal}");
        Console.WriteLine($"Valor Bruto: R${valorBruto:F2}");
        if (freteGratis)
        {
            Console.WriteLine("Frete Grátis!");
        }
        else
        {
            Console.WriteLine("Frete R$13.99");
        }
        if (desconto > 0)
        {
            Console.WriteLine($"Desconto Aplicado: R${desconto:F2}");
        }
        Console.WriteLine($"Valor Final: R${valorFinal:F2}");
        Console.WriteLine("--------------------------------\n");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Inicializa a lista de produtos disponíveis com nome preço e qtd
        List<Produto> produtos = new()
        {
            new Produto("X-Burguer", 30.99, 15),
            new Produto("Refrigerante", 7.50, 15),
            new Produto("Sorvete", 11.30, 15)
        };

        Pedido pedido = new();
        int opcao;

        do
        {
            // Menu
            Console.WriteLine("\n----- Menu -----");
            Console.WriteLine("(1) Listar produtos");
            Console.WriteLine("(2) Adicionar produto ao pedido");
            Console.WriteLine("(3) Remover produto do pedido");
            Console.WriteLine("(4) Visualizar pedido");
            Console.WriteLine("(5) Finalizar");
            Console.Write("Escolha: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    // Lista todos os produtos
                    produtos.ForEach(p => Console.WriteLine(p));
                    break;
                case 2:
                    // Adiciona um produto ao pedido
                    Console.Write("Número do produto: ");
                    int escolha = int.Parse(Console.ReadLine()) - 1;
                    Console.Write("Quantidade: ");
                    int qtd = int.Parse(Console.ReadLine());
                    if (escolha >= 0 && escolha < produtos.Count)
                        pedido.AdicionarProduto(produtos[escolha], qtd);
                    else
                        Console.WriteLine("Produto inválido.");
                    break;
                case 3:
                    // Remove um produto do pedido
                    Console.Write("Linha para remover: ");
                    escolha = int.Parse(Console.ReadLine()) - 1;
                    if (escolha >= 0 && escolha < produtos.Count)
                        pedido.RemoverPorLinha(escolha);
                    else
                        Console.WriteLine("Produto inválido.");
                    break;
                case 4:
                    // Mostra um resumo do pedido no momento
                    pedido.VisualizarPedido();
                    break;
                case 5:
                    // Finaliza a compra do produto e o programa
                    pedido.ExibirResumoFinal();
                    Console.WriteLine("Finalizando programa.");
                    break;
                default:
                    // Opção inválida digitada pelo usuário
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        } while (opcao != 5); // Mantém o programa em execução até o usuário escolher finalizar
    }
}
