namespace ConsoleTodo;

// Baslık
// Icerik
// Atanan Kisi (Takım üyelerişnden biri olmalı)
// Büyüklük (XS, S, M, L, XL)
public class Card
{
    public string Header { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string TeamMember { get; set; } = string.Empty;
    public Size Size { get; set; }
}