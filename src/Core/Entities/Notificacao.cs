﻿using System;
using System.Collections.Generic;

namespace TryLog.Core.Entities
{
    /// <summary>
    /// Classe responsável por armazenar pedidos de notificação, permitindo que usuário configure a forma como deseja ser notificado
    /// além de nível de severidade e plataformas.
    /// </summary>
    public class Notificacao
    {
        public long Id { get; private set; }
        public Usuario Usuario { get; private set; }
        public List<EnumSeveridade> NiveisSeveridadeAlerta { get; private set; }
        public List<EnumSituacao> SituacoesAlerta { get; private set; }

    }
}
