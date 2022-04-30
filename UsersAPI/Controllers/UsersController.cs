using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UsersAPI.Data;
using UsersAPI.Models;
using UsersAPI.Repository.UsersRep;

namespace UsersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        UsersDbContext _context;
        IUsersRepository _repo;

        public UsersController(UsersDbContext dbContext, IUsersRepository repo)
        {
            _repo = repo;
            _context = dbContext;
        }

        [HttpGet("GetUsers")]
        public ActionResult<List<User>> GetUsers([FromHeader] string login, [FromHeader] string password)
        {
            var requester = _repo.GetUserByLoginAndPassword(login, password);
            if (requester == default)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            if (requester.Admin)
            {
                var _users = _repo.GetActiveUsers();
                if (_users == default)
                    return NotFound();
                return Ok(_users);
            }
            return StatusCode(StatusCodes.Status403Forbidden);
        }

        [HttpGet("GetUserByLogin")]
        public ActionResult<List<User>> GetUserByLogin([FromHeader] string login, [FromHeader] string password, [FromHeader] string desiredUsersLogin)
        {
            var requester = _repo.GetUserByLoginAndPassword(login, password);
            if (requester == default) return StatusCode(StatusCodes.Status403Forbidden);
            
            if (requester.Admin)
            {
                var _user = _repo.GetUserByLogin(desiredUsersLogin);
                if (_user == default)
                    return NotFound();
                return Ok(_user);
            }
            return StatusCode(StatusCodes.Status403Forbidden);
        }

        [HttpGet("GetUserByLoginAndPassword")]
        public ActionResult<User> GetUserByLoginAndPassword([FromHeader] string login, [FromHeader] string password)
        {
            var user = _repo.GetUserByLoginAndPassword(login, password);
            if (user == default)
            {
                return BadRequest("Wrong Password or Login");
            }
            return Ok(user);
        }

        // Возвращает юзеров, исходя из указанного возраста
        [HttpGet("GetUsersByAge")]
        public ActionResult<List<User>> GetUsersByAge([FromHeader] string login, [FromHeader] string password, [FromHeader] int age)
        {
            var user = _repo.GetUserByLoginAndPassword(login, password);
            if (user == default)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            if (user.Admin)
            {
                var _users = _repo.GetUsersByAge(age);
                if (_users == default)
                    return NotFound();
                return Ok(_users);
            }
            return StatusCode(StatusCodes.Status403Forbidden);
        }

        [HttpPost("CreateUserForAdmins")]
        public IActionResult CreateUserForAdmins([FromHeader] string login,
                                    [FromHeader] string password,
                                    [FromBody] UserDataForRequest user)
        {
            var requester = _repo.GetUserByLoginAndPassword(login, password);
            if (requester == default)
                return StatusCode(StatusCodes.Status403Forbidden);
            if (requester.Admin)
            {
                if (ModelState.IsValid)
                {
                    var _user = _repo.CreateUser(user.UserFromUserDataForRequest(), requester.Name);
                    if (_user == default)
                        return BadRequest("Не удалось создать пользователя");
                    return Ok(_user);
                }
                else
                    return BadRequest();
            }
            return StatusCode(StatusCodes.Status403Forbidden);
        }

        [HttpPost("CreateUserForUsers")]
        public IActionResult CreateUserForUsers([FromBody] UserDataForRequest user)
        {
            user.Admin = false;
            if (ModelState.IsValid)
            {
                var _user = _repo.CreateUser(user.UserFromUserDataForRequest(),user.Name);
                if (_user == default)
                    return BadRequest("Не удалось создать пользователя");
                return Ok(_user);
            }
            else
                return BadRequest(ModelState.Values);
    }
    // Обновление свойств юзера
    [HttpPut("UpdateUserProps")]
    public IActionResult UpdateUserProps([FromHeader] string login,
                                [FromHeader] string password,
                                [FromHeader] string loginChangeableUser,
                                [FromBody] UserProps userProps)
    {
        var requester = _repo.GetUserByLoginAndPassword(login, password);
        if (requester == default)
            return StatusCode(StatusCodes.Status403Forbidden);

        if (ModelState.IsValid)
        {
            if (requester.Login == loginChangeableUser)
            {
                _repo.UpdateUserProps(requester, userProps, requester.Name);
                return Ok(requester);
            }
            else if (requester.Admin)
            {
                var user = _repo.GetUserByLogin(loginChangeableUser);
                if (user != default && user.RevokedOn == null )
                {
                    _repo.UpdateUserProps(user, userProps, requester.Name);
                    return Ok(user);
                }
                return StatusCode(StatusCodes.Status403Forbidden);
            }
        }
        return StatusCode(StatusCodes.Status403Forbidden);

    }

    [HttpPut("UpdateUserPassword")]
    public IActionResult UpdateUserPassword([FromHeader] string login,
                                [FromHeader] string password,
                                [FromHeader] string loginChangeableUser,
                                [FromBody] string newPassword)
    {
        var requester = _repo.GetUserByLoginAndPassword(login, password);
        if (requester == default)
            return StatusCode(StatusCodes.Status403Forbidden);

        if (requester.Login == loginChangeableUser)
        {
            if (requester.RevokedOn == null)
            {
                _repo.UpdateUserPassword(requester, newPassword, requester.Name);
                return Ok(requester);
            }
            return StatusCode(StatusCodes.Status403Forbidden);
        }
        else if (requester.Admin)
        {
            var user = _repo.GetUserByLogin(loginChangeableUser);
            if (user != default && user.RevokedOn == null)
            {
                _repo.UpdateUserPassword(user, newPassword, requester.Name);
                return Ok(user);
            }
            return StatusCode(StatusCodes.Status403Forbidden);
        }
        return StatusCode(StatusCodes.Status403Forbidden);

    }

    [HttpPut("UpdateUserLogin")]
    public IActionResult UpdateUserLogin([FromHeader] string login,
                                [FromHeader] string password,
                                [FromHeader] string loginChangeableUser,
                                [FromBody] string newLogin)
    {
        var requester = _repo.GetUserByLoginAndPassword(login, password);
        if (requester == default)
            return StatusCode(StatusCodes.Status403Forbidden);

        if (requester.Login == loginChangeableUser)
        {
            if (requester.RevokedOn == null)
            {
                _repo.UpdateUserLogin(requester, newLogin, requester.Name);
                return Ok(requester);
            }
            return StatusCode(StatusCodes.Status403Forbidden);
        }
        else if (requester.Admin)
        {
            var user = _repo.GetUserByLogin(loginChangeableUser);
            if (user != default && user.RevokedOn == null)
            {
                _repo.UpdateUserLogin(user, newLogin, requester.Name);
                return Ok(user);
            }
            return StatusCode(StatusCodes.Status403Forbidden);
        }
        return StatusCode(StatusCodes.Status403Forbidden);

    }

    [HttpPut("RecoverUser")]
    public IActionResult RecoverUser([FromHeader] string login,
                                [FromHeader] string password,
                                [FromBody] string loginChangeableUser)
    {
        var requester = _repo.GetUserByLoginAndPassword(login, password);
        if (requester == default || !requester.Admin)
            return StatusCode(StatusCodes.Status403Forbidden);
        var _user = _repo.GetUserByLogin(loginChangeableUser);
        if (_user == default)
            return NotFound();
        _repo.RecoverUser(_user);
        return Ok(_user);
    }

    [HttpDelete("SoftDeleteUser")]
    public IActionResult SoftDeleteUser([FromHeader] string login,
                                [FromHeader] string password,
                                [FromBody] string loginChangeableUser)
    {
        var requester = _repo.GetUserByLoginAndPassword(login, password);
        if (requester == default || !requester.Admin)
            return StatusCode(StatusCodes.Status403Forbidden);
        var _user = _repo.GetUserByLogin(loginChangeableUser);
        if (_user == default)
            return NotFound();
        _repo.SoftDeleteUser(_user, requester.Name);
        return Ok(_user);
    }
    [HttpDelete("HardDeleteUser")]
    public IActionResult HardDeleteUser([FromHeader] string login,
                                [FromHeader] string password,
                                [FromBody] string loginChangeableUser)
    {
        var requester = _repo.GetUserByLoginAndPassword(login, password);
        if (requester == default || !requester.Admin)
            return StatusCode(StatusCodes.Status403Forbidden);
        var _user = _repo.GetUserByLogin(loginChangeableUser);
        if (_user == default)
            return NotFound();
        _repo.HardDeleteUser(_user);
        return Ok("Удалён");
    }


}
}
