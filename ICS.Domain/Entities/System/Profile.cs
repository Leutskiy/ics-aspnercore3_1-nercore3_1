using System;
using System.Security.Cryptography;

namespace ICS.Domain.Entities.System
{
    /// <summary>
    /// Профиль
    /// </summary>
    public class Profile
    {
        protected Profile()
        {
        }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public virtual Guid Id { get; protected set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public virtual Guid UserId { get; protected set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public virtual User User { get; protected set; }

        /// <summary>
        /// Порядковый номер в системе
        /// (порядок расчитывается по дате создания)
        /// </summary>
        public long OrdinalNumber { get; protected set; }

        /// <summary>
        /// Фотография
        /// </summary>
        public byte[] Photo { get; protected set; }

        /// <summary>
        /// Коллекция строк
        /// </summary>
        public string WebPages { get; protected set; }

        /// <summary>
        /// Первоначальная инициализация
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="ordinalNumber">Порядковый номер</param>
        public void Initialize(
            Guid id,
            Guid userId,
            long ordinalNumber)
        {
            Id = id;
            UserId = userId;
            OrdinalNumber = ordinalNumber;
            Photo = null;
        }

        /// <summary>
        /// Установить фото
        /// </summary>
        /// <param name="photo">Фото</param>
        public void SetPhoto(byte[] photo)
        {
            if (CreateMd5(Photo) == CreateMd5(photo))
            {
                return;
            }

            Photo = photo;
        }

        /// <summary>
        /// Установить веб-сраницы
        /// </summary>
        /// <param name="webpages">Веб-страницы</param>
        public void SetWebPages(string webpages)
        {
            if (WebPages == webpages)
            {
                return;
            }

            WebPages = webpages;
        }

        /// <summary>
        /// Создать MD5 хэш по контенту
        /// </summary>
        /// <param name="content">Контент</param>
        /// <returns>MD5 хэш контента</returns>
        private static string CreateMd5(byte[] content)
        {
            if (content == null)
            {
                return null;
            }

            using (var md5Hasher = MD5.Create())
            {
                var md5Hash = md5Hasher.ComputeHash(content);
                return Convert.ToBase64String(md5Hash);
            }
        }

        /// <summary>
        /// Обновить профиль
        /// </summary>
        /// <param name="avatar"></param>
        /// <param name="webpages"></param>
        public void Update(
           byte[] avatar,
           string webpages)
        {
            /*надо добавить проверки на null*/
            SetPhoto(avatar);
            SetWebPages(webpages);

        }
    }
}