using ICS.Domain.Enums;
using System;

namespace ICS.Domain.Models
{
    /// <summary>
    /// Информация о паспортных данных
    /// </summary>
    public sealed class PassportDto
    {
        # region Имя-Фамалия-Отчество (Русский/Английский вариынты)

        /// <summary>
        /// Имя (по-русски)
        /// </summary>
        public string NameRus { get; set; }

        /// <summary>
        /// Имя (по-английски)
        /// </summary>
        public string NameEng { get; set; }

        /// <summary>
        /// Фамилия (по-русски)
        /// </summary>
        public string SurnameRus { get; set; }

        /// <summary>
        /// Фамилия (по-английски)
        /// </summary>
        public string SurnameEng { get; set; }

        /// <summary>
        /// Отчество (по-русски)
        /// </summary>
        public string PatronymicNameRus { get; set; }

        /// <summary>
        /// Отчество (по-ангийски)
        /// </summary>
        public string PatronymicNameEng { get; set; }

        #endregion

        # region Рождение

        /// <summary>
        /// Место рождения
        /// </summary>
        public string BirthPlace { get; set; }

        /// <summary>
        /// Страна рождения
        /// </summary>
        public string BirthCountry { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public Sex? Gender { get; set; }

        /// <summary>
        /// Гражданство (подданство)
        /// </summary>
        public string Citizenship { get; set; }

        #endregion

        #region Резиденция

        /// <summary>
        /// Местожительство
        /// </summary>
        public string Residence { get; set; }

        /// <summary>
        /// Страна постоянного проживания
        /// </summary>
        public string ResidenceCountry { get; set; }

        /// <summary>
        /// Регион в стране постоянного проживания
        /// </summary>
        public string ResidenceRegion { get; set; }

        #endregion

        #region Документ идентификации

        /// <summary>
        /// Документ удостоверяющий личность
        /// </summary>
        public string IdentityDocument { get; set; }

        /// <summary>
        /// Место выдачи документа удостоверяющего личность
        /// </summary>
        public string IssuePlace { get; set; }

        /// <summary>
        /// Код подразделения выдававшего документ
        /// </summary>
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Дата выдачи документа удостоверяющего личность
        /// </summary>
        public DateTime? IssueDate { get; set; }

        #endregion
    }
}