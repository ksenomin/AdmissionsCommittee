namespace Services.Contracts
{
    /// <summary>
    /// Класс хранения статистики туров
    /// </summary>
    public class ApplicantStatistics
    {
        /// <summary>
        /// Количество абитуриентов
        /// </summary>
        public int ApplicantsCount { get; set; }

        /// <summary>
        /// Абитуриенты набравшие 150 баллов+
        /// </summary>
        public int ApplicantsCountPassed { get; set; }
    }
}
