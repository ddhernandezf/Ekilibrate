using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Participante
{
    class QFrecuencia
    {
        public const string List =
                 @"
                 	SELECT S.PREGUNTA,
	 s.ID_PREGUNTA ID_PREGUNTA,
	 pa.SIEMPRE,
	 PA.FRECUENTE,
	 PA.CASI_NUNCA,
	 PA.NUNCA 
	 FROM [PAR.PREGUNTA_TIEMPO] s
			LEFT JOIN (
				SELECT * 
				FROM [PAR.TIEMPO] p 
				WHERE p.ID_PARTICIPANTE = @ID_PARTICIPANTE ) as pa 
	on s.ID_PREGUNTA = pa.ID_PREGUNTA
                 ";

        public const string insert =
            @"
            if Exists(select ID_PREGUNTA from [PAR.TIEMPO]
where id_participante =@ID_PARTICIPANTE and id_pregunta = @ID_PREGUNTA )
begin 
	UPDATE [PAR.TIEMPO]
	SET SIEMPRE=@SIEMPRE,
		FRECUENTE=@FRECUENTE,
		CASI_NUNCA=@CASI_NUNCA,
		NUNCA=@NUNCA
	where ID_PARTICIPANTE=@ID_PARTICIPANTE
	and id_pregunta=@ID_PREGUNTA
end
ELSE
begin
	insert into [PAR.TIEMPO]
	values(@ID_PARTICIPANTE,@ID_PREGUNTA,@SIEMPRE,@FRECUENTE,@CASI_NUNCA,@NUNCA)
end
            ";


    }
}