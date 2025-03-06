namespace TodoList.Models;

public class TodoModel
{
    // Construtor que inicializa o Title e o Id.
    public TodoModel(string title)
    {
        Title = title;
        Id = contId;
        contId++; // Incrementa o contador para o próximo Id.
    }

    // Contador estático que gera IDs únicos para cada novo TodoModel.
    private static int contId = 0;

    // Id é inicializado no construtor e não pode ser modificado depois.
    public int Id { get; init; }

    // Title só pode ser alterado dentro da classe.
    public string Title { get; private set; }

    // IsCompleted pode ser alterado externamente e tem um valor padrão de false.
    public bool IsCompleted { get; set; } = false;

    public void ChangeTitle(string title)
    {
        Title = title;
    }

    public void ChangeIsCompleted(bool isCompleted)
    {
        IsCompleted = isCompleted;
    }

    public void SetInactive()
    {
        Title = "Atividade Deletada";
    }
}
