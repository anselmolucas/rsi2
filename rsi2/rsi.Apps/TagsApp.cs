using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rsi.Entities;
using rsi.Apps;
using rsi.Entities.AdvertiserDetails;

namespace rsi.Apps
{
    public class TagsApp
    {
        private Context _context = new Context();
        private Functions _functions = new Functions();

        public void TagsListProcess()
        {
            //apaga todos os registros da tabela
            _functions.TruncateTable("tags");

            var _advertisersList = _context.Advertisers.Where(x => x.St == status.on).ToList();

            foreach (var _item in _advertisersList)
            {
                string[] _tagsList = extractTagsToArray(_item.Tags.Trim().ToLower());

                if (_tagsList.Length >= 1)
                {
                    for (int i = 0; i <= _tagsList.Length - 1; i++)
                    {
                        string _tagArray = _tagsList[i];
                        var _tagObj = _context.Tags.FirstOrDefault(x => x.TagText == _tagArray);
                        if (_tagObj == null && !String.IsNullOrEmpty(_tagsList[i].Trim().ToLower()))
                        {
                            Tag _tag = new Tag()
                            {
                                TagText = _tagsList[i].Trim().ToLower(),
                                UpdateDate = System.DateTime.Now,
                                AddDate = System.DateTime.Now,
                                AddUserId = 1,
                                UpdateUserId = 1,
                                St = status.on
                            };

                            _context.Tags.Add(_tag);
                            _context.SaveChanges();
                        }
                    }
                }               
            }
        }

        public string[] extractTagsToArray(string _tagsString)
        {
            /*< !--problema: eu quero pegar as tags e criar um link para cada uma,
                    só que eu quero despresar as tags entre parênteses, pois não devem ser exibidas
                    (os textos entre parênteses sempre estarão no início com campo Advertiser.Tag)
                */
            // passo 1: encontar a posição no final dos parenteses ")"
            int posicao = _tagsString.IndexOf(")");

            // passo 2: com a posição do final dos parentes armazenada em "posicao e soma-se +1
            var _tagSemParenteses = _tagsString.Substring(posicao + 1).ToLower().Trim();

            // passo 3: a função "split gera um array com as tags restantes usando como caracter divisor a virgula"
            string[] _tags = _tagSemParenteses.Split(',');

            return _tags;
        }

        public string[] extractTagsHiddenToArray(string _tagsString)
        {
            /*< !--problema: eu quero pegar as tags e criar um link para cada uma,
                    só que eu quero despresar as tags entre parênteses, pois não devem ser exibidas
                    (os textos entre parênteses sempre estarão no início com campo Advertiser.Tag)
                */
            // passo 1: encontar a posição no final dos parenteses ")"
            int posicao = _tagsString.IndexOf(")");
            // passo 2: com a posição do final dos parentes armazenada em "posicao e soma-se +1
            var _tagSemParenteses = _tagsString.Substring(1, posicao).ToLower().Trim();

            // passo 3: a função "split gera um array com as tags restantes usando como caracter divisor a virgula"
            string[] _tags = _tagSemParenteses.Split(',');

            return _tags;
        }

        public List<Tag> tagsListHidden()
        {
            var _advertisersList = _context.Advertisers.Where(x => x.St == status.on).ToList();

            List<Tag> _tagsListHidden = new List<Tag>();

            foreach (var _item in _advertisersList)
            {
                if (_item.Tags.Trim().ToLower().Contains(")"))
                {
                    string[] _tagsList = extractTagsHiddenToArray(_item.Tags.Trim().ToLower());

                    if (_tagsList.Length >= 1)
                    {
                        for (int i = 0; i <= _tagsList.Length - 1; i++)
                        {
                            string _tagArray = _tagsList[i];
                            var _tagObj = _context.Tags.FirstOrDefault(x => x.TagText == _tagArray);
                            if (_tagObj == null && !String.IsNullOrEmpty(_tagsList[i].Trim().ToLower()))
                            {
                                Tag _tag = new Tag()
                                {
                                    TagText = _tagsList[i].Trim().ToLower()
                                };

                                if (_tag.TagText.Contains(")"))
                                    _tag.TagText = _tag.TagText.Substring(0, _tag.TagText.IndexOf(")"));

                                _tagsListHidden.Add(_tag);
                            }
                        }
                    }
                }
            }

            return _tagsListHidden;
        }

        public IList<Tag> List()
        {
            using (var _context = new Context())
            {
                return _context.Tags.Where(x=>x.St == status.on).OrderBy(x => x.TagText).ToList();
            }
        }
    }
}
