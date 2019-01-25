using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Participante
{
    class QAsertiva
    {
        public const string List =
                 @"
                 	SELECT S.PREGUNTA,
	 s.ID_PREGUNTA ID_PREGUNTA,
	 pa.EN_ABSOLUTO,
	 PA.UN_POCO,
	 PA.BASTANTE,
	 PA.MUCHO,
	 pa.MUCHISIMO 
	 FROM [PAR.PREGUNTA_COMUNICACION_ASERTIVA_UNO] s
			LEFT JOIN (
				SELECT * 
				FROM [PAR.COMUNICACION_ASERTIVA_UNO] p 
				WHERE p.ID_PARTICIPANTE = @ID_PARTICIPANTE ) as pa 
	on s.ID_PREGUNTA = pa.ID_PREGUNTA
                 ";
        public const string insert =
            @"
            if Exists(select ID_PREGUNTA from [PAR.COMUNICACION_ASERTIVA_UNO]
where id_participante =@ID_PARTICIPANTE and id_pregunta = @ID_PREGUNTA )
begin 
	UPDATE [PAR.COMUNICACION_ASERTIVA_UNO]
	SET EN_ABSOLUTO=@EN_ABSOLUTO,
		UN_POCO=@UN_POCO,
		BASTANTE=@BASTANTE,
		MUCHO=@MUCHO,
        MUCHISIMO=@MUCHISIMO
	where ID_PARTICIPANTE=@ID_PARTICIPANTE
	and id_pregunta=@ID_PREGUNTA
end
ELSE
begin
	insert into [PAR.COMUNICACION_ASERTIVA_UNO]
	values(@ID_PARTICIPANTE,@ID_PREGUNTA,@EN_ABSOLUTO,@UN_POCO,@BASTANTE,@MUCHO,@MUCHISIMO)
end
            ";

    }
}