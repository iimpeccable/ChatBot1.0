namespace ChatBot1._0GUI
{
    class ChatbotService
    {
        private readonly ResponseService _responseService;

        public ChatbotService(UserProfile user)
        {
            _responseService = new ResponseService(user);
        }

        public (string response, Quiz? quiz) ProcessInput(string input)
        {
            return _responseService.ProcessInput(input);
        }
    }
}
