
namespace MovieReview.Core.Exceptions;

public class NotFoundException(string message) : DomainException(message);
