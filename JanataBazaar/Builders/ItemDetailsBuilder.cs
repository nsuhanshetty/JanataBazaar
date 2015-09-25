using JanataBazaar.Models;
using NHibernate.Linq;
using System;
using System.Collections;
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
                        select _item.QuantityUnit).Distinct().ToList();
            }
        }
        public static IList GetItemsList(string name, string sectionName, string brand = "")
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                Item itemAlias = null;
                Section sectionAlias = null;

                IList itemList = (from item in (session.QueryOver<Item>(() => itemAlias)
                                        .JoinAlias(() => itemAlias.Section, () => sectionAlias)
                                        .Where(NHibernate.Criterion.Restrictions.On(() => itemAlias.Name).IsLike(name + "%"))
                                        .Where(NHibernate.Criterion.Restrictions.On(() => itemAlias.Brand).IsLike(brand + "%"))
                                        .Where(() => sectionAlias.Name == sectionName)
                                        .List())
                                  select new { item.ID, item.Name, item.QuantityUnit })
                                  .ToList();
                return itemList;
            }
        }

        public static bool ItemExists(string name, string brand, string unit, string sectionName)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                int sectID = (from sect in session.Query<Section>()
                              where sect.Name == sectionName
                              select sect.ID).SingleOrDefault();
                return session.Query<Item>().Any(x => (x.Name == name && x.QuantityUnit == unit &&
                                                       x.Brand == brand && x.Section.ID == sectID));
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

    public class PackageDetailsBuilder
    {
        public static bool PackageExists(string packageName)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Package>().Any(x => x.Name == packageName);
            }
        }

        public static Package GetPackage(string packageName)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                Package pack = (from _pack in session.Query<Package>()
                                where _pack.Name == packageName
                                select _pack).FirstOrDefault();
                return pack;
            }
        }
    }

    public class ItemSKUBuilder
    {
        public static ItemSKU GetItemSKUInfo(int _ID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var _item = session.QueryOver<ItemSKU>()
                    .Where(x => x.ID == _ID)
                        .Fetch(i => i.Item).Eager
                        .Future().SingleOrDefault();
                return _item;
            }
        }

        public static bool IsItemInStock(int _ID)
        {
            //todo: ask whats the minimum quantity for wholesale sale
            ItemSKU itemskuAlias = null;
            var minWholesaleQuant = 0;

            using (var session = NHibernateHelper.OpenSession())
            {
                //todo: Combine both the statments
                ItemSKU _item = session.QueryOver(() => itemskuAlias)
                    .Where(() => itemskuAlias.ID == _ID)
                    .SingleOrDefault();

                return _item.PackageQuantity * _item.QuantityPerPack > minWholesaleQuant ? true : false;
            }
        }
    }
}
