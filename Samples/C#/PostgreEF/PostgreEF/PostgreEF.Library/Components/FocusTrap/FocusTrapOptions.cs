using System.Text.Json.Serialization;

namespace PostgreEF.Library.Components.FocusTrap
{

    /// <summary>
    /// Subconjunto (o mais usado no dia a dia) das opções aceitas pela biblioteca
    /// focus-trap. Veja a documentação oficial para a lista completa:
    /// https://github.com/focus-trap/focus-trap#createfocustrapelement-createoptions
    ///
    /// Propriedades não definidas (null) simplesmente não são enviadas ao JS,
    /// deixando a biblioteca usar seus próprios valores padrão.
    /// </summary>
    public class FocusTrapOptions
    {
        /// <summary>
        /// Seletor CSS (ex: "input", "#nome", ".primeiro-campo") do elemento que
        /// deve receber foco ao ativar o trap. Se omitido, o focus-trap escolhe
        /// automaticamente o primeiro elemento focável.
        /// </summary>
        [JsonPropertyName("initialFocus")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? InitialFocus { get; set; }

        /// <summary>
        /// Seletor CSS usado como foco de fallback quando não há elementos focáveis.
        /// </summary>
        [JsonPropertyName("fallbackFocus")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? FallbackFocus { get; set; }

        /// <summary>Tecla Esc desativa o trap. Padrão da lib: true.</summary>
        [JsonPropertyName("escapeDeactivates")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? EscapeDeactivates { get; set; }

        /// <summary>Clique fora do container desativa o trap. Padrão da lib: false.</summary>
        [JsonPropertyName("clickOutsideDeactivates")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ClickOutsideDeactivates { get; set; }

        /// <summary>Devolve o foco ao elemento que o tinha antes da ativação. Padrão: true.</summary>
        [JsonPropertyName("returnFocusOnDeactivate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ReturnFocusOnDeactivate { get; set; }

        /// <summary>Permite cliques fora sem desativar o trap (útil p/ overlays customizados).</summary>
        [JsonPropertyName("allowOutsideClick")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AllowOutsideClick { get; set; }

        /// <summary>Evita rolagem automática até o elemento focado.</summary>
        [JsonPropertyName("preventScroll")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? PreventScroll { get; set; }
    }
}
