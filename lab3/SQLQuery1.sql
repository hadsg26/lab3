﻿SELECT AVG(HREALES) FROM ESTUDIANTESTAREAS A INNER JOIN TAREASGENERICAS B ON (A.CODTAREA = B.CODIGO) WHERE CODASIG = 'HAS' ;