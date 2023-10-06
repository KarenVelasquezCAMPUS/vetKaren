namespace Core.Entities;
public class RefreshToken : BaseEntity
{
    public string Token { get; set; }
    public string RefreshTokenK { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public bool IsActive { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}