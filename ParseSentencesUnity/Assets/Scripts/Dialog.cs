public class Dialog
{
    private string sentence;
    private string[] answers;
    private int propertyId;

    public Dialog(string sentence, string[] answers, int propertyId)
    {
        this.sentence = sentence;
        this.answers = answers;
        this.propertyId = propertyId;
    }

    public string Sentence => sentence;

    public string[] Answers => answers;

    public int PropertyId => propertyId;
}