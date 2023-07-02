using System;
using System.Text;

namespace VG.CDF.Client.Infrastructure.Extentions;

public static class HttpQueryExtentions
{
    private const char _sepRouteSymb = '?';
    private const char _sepParamsSymb = '&';
    
    public static string? GetQuery(this object entity, string? url = null )
    {
        StringBuilder query = new StringBuilder();
        string str;
        if (url != null)
        {
            url.TrimEnd('/');
            query.Append(url);
        }
        
        //простой тип, без полей
        if(entity is ValueType || entity is string)
        {
            query.Append(entity.ToString());
        }
        else
        {
            query.Append(_sepRouteSymb);
            foreach (var prop in entity.GetType().GetProperties())
            {
                if (prop.GetValue(entity) != null)
                {
                    query.Append(prop.Name);
                    query.Append("=");
                    query.Append(prop.GetValue(entity));
                    query.Append(_sepParamsSymb);
                }
            }
        }
        
        return query.ToString().ToLower().TrimEnd(new char[]{_sepParamsSymb,_sepRouteSymb});

    }
}