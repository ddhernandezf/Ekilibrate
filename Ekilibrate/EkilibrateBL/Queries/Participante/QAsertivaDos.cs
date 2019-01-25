using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Participante
{
    class QAsertivaDos
    {
        public const string List =
                 @"
                 	SELECT S.PREGUNTA,
	 s.ID_PREGUNTA ID_PREGUNTA,
	 pa.SIEMPRE_LO_HAGO,
	 PA.HABITUALMENTEBIT,
	 PA.MITAD_VECES,
	 PA.RARAMENTE,
	 PA.NUNCA 
	 FROM [PAR.PREGUNTA_COMUNICACION_ASERTIVA_DOS] s
			LEFT JOIN (
				SELECT * 
				FROM [PAR.COMUNICACION_ASERVITA_DOS] p 
				WHERE p.ID_PARTICIPANTE = @ID_PARTICIPANTE ) as pa 
	on s.ID_PREGUNTA = pa.ID_PREGUNTA
                 ";
        public const string insert =
           @"
            if Exists(select ID_PREGUNTA from [PAR.COMUNICACION_ASERVITA_DOS]
where id_participante =@ID_PARTICIPANTE and id_pregunta = @ID_PREGUNTA )
begin 
	UPDATE [PAR.COMUNICACION_ASERVITA_DOS]
	SET SIEMPRE_LO_HAGO=@SIEMPRE_LO_HAGO,
		HABITUALMENTEBIT=@HABITUALMENTEBIT,
		MITAD_VECES=@MITAD_VECES,
		RARAMENTE=@RARAMENTE,
        NUNCA=@NUNCA
	where ID_PARTICIPANTE=@ID_PARTICIPANTE
	and id_pregunta=@ID_PREGUNTA
end
ELSE
begin
	insert into [PAR.COMUNICACION_ASERVITA_DOS]
	values(@ID_PARTICIPANTE,@ID_PREGUNTA,@SIEMPRE_LO_HAGO,@HABITUALMENTEBIT,@MITAD_VECES,@RARAMENTE,@NUNCA)
end
            ";

    }
}