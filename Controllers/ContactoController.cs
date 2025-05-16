public class ContactoController : Controller
{
    private readonly IConfiguration _config;

    public ContactoController(IConfiguration config)
    {
        _config = config;
    }

    [HttpGet]
    public IActionResult Index() => View();

    [HttpPost]
    public async Task<IActionResult> Index(EmailFormModel model)
    {
        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(_config["Email:User"], _config["Email:Password"]),
            EnableSsl = true,
        };

        var mail = new MailMessage
        {
            From = new MailAddress(model.Correo),
            Subject = "Contacto desde AccessGranted",
            Body = model.Mensaje,
            IsBodyHtml = false,
        };
        mail.To.Add("tucorreo@ejemplo.com");

        await smtpClient.SendMailAsync(mail);
        ViewBag.Message = "Mensaje enviado con éxito.";
        return View();
    }
}