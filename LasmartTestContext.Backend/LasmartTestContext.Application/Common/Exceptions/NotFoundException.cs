namespace LasmartTestContext.Application.Common.Exceptions;

/// <summary>
/// Исключение отсутствия 
/// </summary>
public class NotFoundException : Exception
{
    /// <summary>
    /// Исключение с пользовательским текстом
    /// </summary>
    /// <param name="message">Текст исключения</param>
    public NotFoundException(string message): base(message) { }
}