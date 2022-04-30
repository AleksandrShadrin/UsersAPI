namespace UsersAPI.Models
{
    public class UserExtensions
    {
        static string GenderToString(int gender) => gender switch
        {
            0 => "Женщина",
            1 => "Мужчина",
            _ => "Неизвестно"
        };
    }
}

