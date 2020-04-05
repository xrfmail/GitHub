<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="text" encoding="UTF-8" indent="yes"/>
	<xsl:preserve-space elements="*" />

	<xsl:template match="GameCatalog">&lt;style&gt;
	th {
		font-family: Courier New;
		font-size: 12pt;
		border: 1pt solid silver;
		background-color: #EEEEEE;
	}
	td.plain {
		font-family: Courier New;
		font-size: 10pt;
		border: 1pt solid white;
	}
	td {
		font-family: Courier New;
		font-size: 10pt;
		border: 1pt solid silver;
	}
	td.sub {
		font-family: Courier New;
		font-size: 10pt;
		border: 1pt solid silver;
		background-color: #EEEEEE;
	}
&lt;/style&gt;
&lt;table&gt;
		<xsl:for-each select="Games/Game"><xsl:call-template name="Game" /></xsl:for-each>
&lt;/table&gt;</xsl:template>

	<xsl:template match="Game" name="Game">
	&lt;tr&gt;
		&lt;th colspan=3&gt;<xsl:value-of select="@name" />&lt;/th&gt;
	&lt;/tr&gt;&lt;tr&gt;
		&lt;td&gt;<xsl:value-of select="@genre" />&lt;/td&gt;
		&lt;td&gt;ASIN: <xsl:value-of select="@isbn" />&lt;/td&gt;
		&lt;td&gt;CD Key: <xsl:value-of select="CDKey" />&lt;/td&gt;
	&lt;/tr&gt;
	<xsl:if test="Url != ''">
	&lt;tr&gt;&lt;td colspan=3 class="sub"&gt;
	&lt;a href="<xsl:value-of select='Url' />"&gt;<xsl:value-of select="Url" />&lt;/a&gt;
	&lt;/td&gt;&lt;/tr&gt;
	</xsl:if>
	<xsl:if test="Developer/@name != ''">
	&lt;tr&gt;
		&lt;td class="sub"&gt;Developer&lt;/td&gt;
		&lt;td colspan=2&gt;
		<xsl:if test="Developer/@url != ''">&lt;a href="<xsl:value-of select='Developer/@url' />"&gt;</xsl:if>
		<xsl:value-of select="Developer/@name" />
		<xsl:if test="Developer/@url != ''">&lt;/a&gt;</xsl:if>
		&lt;/td&gt;
	&lt;/tr&gt;
	</xsl:if>
	<xsl:if test="Publisher/@name != ''">
	&lt;tr&gt;
		&lt;td class="sub"&gt;Publisher&lt;/td&gt;
		&lt;td colspan=2&gt;
		<xsl:if test="Publisher/@url != ''">&lt;a href="<xsl:value-of select='Publisher/@url' />"&gt;</xsl:if>
		<xsl:value-of select="Publisher/@name" />
		<xsl:if test="Publisher/@url != ''">&lt;/a&gt;</xsl:if>
		&lt;/td&gt;
	&lt;/tr&gt;
	</xsl:if>
	<xsl:if test="PatchInfo != ''">
	&lt;tr&gt;&lt;td colspan=3 class="sub"&gt;Patch Info&lt;/td&gt;&lt;/tr&gt;
	&lt;tr&gt;
		&lt;td colspan=3&gt;<xsl:call-template name="replace"><xsl:with-param name="string" select="PatchInfo"/></xsl:call-template>&lt;/td&gt;
	&lt;/tr&gt;
	</xsl:if>
	<xsl:if test="Cheats != ''">
	&lt;tr&gt;&lt;td colspan=3 class="sub"&gt;Cheats&lt;/td&gt;&lt;/tr&gt;
	&lt;tr&gt;
		&lt;td colspan=3&gt;<xsl:call-template name="replace"><xsl:with-param name="string" select="Cheats/Setup"/></xsl:call-template>&lt;/td&gt;
	&lt;/tr&gt;
	<xsl:for-each select="Cheats/CheatCodes/Code">
	&lt;tr&gt;
		&lt;td valign=top&gt;<xsl:value-of select="@code" />&lt;/td&gt;
		&lt;td valign=top colspan=2&gt;<xsl:value-of select="Effect" />&lt;/td&gt;
	&lt;/tr&gt;
	</xsl:for-each>
	</xsl:if>
	<xsl:if test="Walkthrough != ''">
	&lt;tr&gt;&lt;td colspan=3 class="sub"&gt;Walthrough&lt;/td&gt;&lt;/tr&gt;
	&lt;tr&gt;
		&lt;td colspan=3&gt;<xsl:call-template name="replace"><xsl:with-param name="string" select="Walkthrough"/></xsl:call-template>&lt;/td&gt;
	&lt;/tr&gt;
	</xsl:if>
	&lt;tr&gt;&lt;td class="plain" colspan=3&gt;&amp;nbsp;&lt;/td&gt;&lt;/tr&gt;
	</xsl:template>

	<xsl:template name="replace">
		<xsl:param name="string"/>
		<xsl:choose>
			<xsl:when test="contains($string,'&#10;')">
				<xsl:value-of select="substring-before($string,'&#10;')"/>
				&lt;br/&gt;
				<xsl:call-template name="replace">
					<xsl:with-param name="string" select="substring-after($string,'&#10;')"/>
				</xsl:call-template>
			</xsl:when>
			<xsl:otherwise>
				<xsl:value-of select="$string"/>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>
</xsl:stylesheet>

<!--
<xsl:call-template name="replace"><xsl:with-param name="string" select="
"/></xsl:call-template>
-->
<!--
    <Game name="Hitman 2 Silent Assassin" genre="TPS" isbn="B00005V9DX">
      <CDKey />
      <Url />
      <Developer name="" url="" />
      <Publisher name="Eidos" url="http://www.eidos.com" />
      <PatchInfo />
      <Cheats>
        <Setup>Hit the ~ key in game...  I think...</Setup>
        <CheatCodes>
          <Code code="IOIGives">
            <Effect>All items</Effect>
          </Code>
        </CheatCodes>
      </Cheats>
      <Walkthrough />
    </Game>
-->