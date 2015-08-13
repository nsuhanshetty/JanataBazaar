using JanataBazaar.Models;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanataBazaar.Builders
{
    public class ItemDetailsBuilder
    {
        public static bool SectionExists(string sectionName)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Section>().Any(x => x.Name == sectionName);
            }
        }

        public static Section GetSection(string _name)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                Section sect = (from _sect in session.Query<Section>()
                                where _sect.Name == _name
                                select _sect).SingleOrDefault();
                return sect;
            }
        }

        public static List<Section> GetSectionsList()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Section>().ToList();
            }
        }

        public static List<string> GetUnitList()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return (from _item in session.Query<Item>()
                        select _item.QuantityUnit).ToList();
            }
        }

        public static List<Item> GetItemsList(string name, string sectionName)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                Item itemAlias = null;

                Section section = GetSection(sectionName);
                List<Item> itemList = session.QueryOver<Item>(() => itemAlias)
                                   .Where(NHibernate.Criterion.Restrictions.On(() => itemAlias.Name).IsLike(name + "%"))
                                   .Where(() => itemAlias.Section.ID == section.ID)
                                   .List() as List<Item>;
                return itemList;
            }
        }

        public static bool ItemExists(string name, string unit, string sectionName)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                int sectID = (from sect in session.Query<Section>()
                              where sect.Name == sectionName
                              select sect.ID).SingleOrDefault();
                return session.Query<Item>().Any(x => (x.Name == name && x.QuantityUnit == unit
                                                       && x.Section.ID == sectID));
            }
        }

        public static Item GetItemInfo(int _ID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var _item = session.QueryOver<Item>()
                    .Where(x => x.ID == _ID)
                        .Fetch(s => s.Section).Eager
                        .Future().SingleOrDefault();
                return _item;
            }
        }
    }
}
