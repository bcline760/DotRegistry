import { Entity } from "./entity.model";

export class Provider extends Entity {
  constructor() {
    super();
    this.id = '';
    this.installCount = 0;
    this.lastPublished = new Date();
    this.name = '';
    this.namespace = '';
    this.protocols = [];
    this.version = '';
    this.publishedBySlug = '';
    this.tags = null;
  }

  /**
   * The ID of this provider
   */
  public id: string;

  /**
  * Get how many times this provider has been installed
  */
  public installCount: number;

  /**
  * The date the last time this provider was published
  */
  public lastPublished: Date;

  /**
  * The name of the provider
  */
  public name: string;

  /**
  * The namespace of the provider, usually the name of the repository
  */
  public namespace: string;

  /**
  * Terraform protocols supported by this provider
  */
  public protocols: string[];

  /**
  * The latest version of this provider
  */
  public version: string;

  /**
  * The last user who published the provider
  */
  public publishedBySlug: string;

  /**
  * Any tags associated with provider
  */
  public tags: string[] | null;
}
